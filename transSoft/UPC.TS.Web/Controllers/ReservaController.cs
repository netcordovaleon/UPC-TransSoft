using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
using UPC.TS.BusinessLogic;
using UPC.TS.BusinessContract;
using UPC.TS.Web.Models;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using AutoMapper;
using UPC.TS.Infraestructure.Constantes;

namespace UPC.TS.Web.Controllers
{
    public class ReservaController : Controller
    {
        #region CONTRUCTOR

        IConsultaProgramacionLogic _consultaProgramacionLogic;
        IUsuarioLogic _usuarioLogic;
        IReservaLogic _reservaLogic;
        IClienteLogic _clienteLogic;
        public ReservaController()
        {
            
            this._consultaProgramacionLogic = Configuration.Unity.Container.Resolve<IConsultaProgramacionLogic>();
            this._usuarioLogic = Configuration.Unity.Container.Resolve<IUsuarioLogic>();
            this._reservaLogic = Configuration.Unity.Container.Resolve<IReservaLogic>();
            this._clienteLogic = Configuration.Unity.Container.Resolve<IClienteLogic>();
        }

        #endregion

        #region CONSULTA DE PROGRAMACION
        // GET: /Reserva/
        public ActionResult Programacion(FiltrosReservaModels filtros)
        {
            var model = new ReservaModels();
            var listadoProgramacion = _consultaProgramacionLogic.ListarProgramacion(filtros.DESORI, filtros.DESDES, filtros.FECSAL);
            model.filtros = filtros;
            model.listaProgramacion = model.castProgramacionType((List<VWCONSULTAPROGRAMACION>)listadoProgramacion);
            return View(model);
        }
        #endregion

        #region REGISTRO DE USUARIOS O LOGIN EN RESERVA
        public ActionResult RegistroUsuario(int? CODPRO_ORI, int? CODPRO_DES) {
            var model = new ReservaUsuarioModels();
            if (CODPRO_ORI.HasValue)
                model.CODPRO_ORI = CODPRO_ORI.Value;
            if (CODPRO_DES.HasValue)
                model.CODPRO_DES = CODPRO_DES.Value;
            return View(model);
        }

        public JsonResult IngresarSistema(ReservaUsuarioModels model) {
            var entidad = Mapper.Map<UsuarioModels, USUARIO>(model.usuario);
            var result = _usuarioLogic.IngresarSistema(entidad);
            if (result.Success) {
                Session[Sesiones.sessionUsuarioLog] = model.usuario.LOGUSU.ToUpper();
            }
            return Json(result);
        }

        public JsonResult RegistrarUsuario(ReservaUsuarioModels model) {
            var usuario = Mapper.Map<UsuarioModels, USUARIO>(model.usuario);
            var cliente = new CLIENTE(){  CORCLI = usuario.LOGUSU };
            var result = _usuarioLogic.AgregarUsuarioReserva(usuario, cliente);
            if (result.Success) {
                Session[Sesiones.sessionUsuarioLog] = model.usuario.LOGUSU.ToUpper();
            }
            return Json(result);
        }

        #endregion

        #region GENERAR RESERVA SEELCCION ASIENTO
        public ActionResult GenerarReserva(int? CODPRO_ORI, int? CODPRO_DES) {
            Session[Sesiones.sessionListaPasajeros] = null;
            var model = new ReservaModels();
            if (CODPRO_ORI.HasValue)
                model.CODPRO_ORI = CODPRO_ORI.Value;
            if (CODPRO_DES.HasValue)
                model.CODPRO_DES = CODPRO_DES.Value;
            return View(model);
        }

        public ActionResult GenerarReservaPasajes(int? CODPRO, int? CODPRODES) {
            var reserva = new RESERVA() { 
                 CODPRO = CODPRO.Value,
                 FECRES = DateTime.Now,
                 ESTTRAN = Infraestructure.Enum.EstadoTranReserva.RESERVADO,
                 CODCLI = _clienteLogic.ObtenerUsuarioPorCorreo(Session[Sesiones.sessionUsuarioLog].ToString()).CODCLI,
            };
            if (CODPRODES.HasValue) { reserva.CODPRODES = CODPRODES.Value; }
            var result = _reservaLogic.RegistrarReserva((List<PASAJERO>)Session[Sesiones.sessionListaPasajeros], reserva);
            return Json(result);
            
        }

        public ActionResult RegistrarAsientoPas(PasajeroModels pasajero) {
            try
            {
                var entidadPasajero = Mapper.Map<PasajeroModels, PASAJERO>(pasajero);
                List<PASAJERO> listPasajero;
                if (Session[Sesiones.sessionListaPasajeros] == null)
                {
                    listPasajero = new List<PASAJERO>();
                    if (string.IsNullOrWhiteSpace(pasajero.NUMASI_DES)) {
                        entidadPasajero.NUMASI = pasajero.NUMASI_ORI;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeIDA;
                        listPasajero.Add(entidadPasajero);
                    } else {
                        //REGISTRAMOS LA IDA
                        entidadPasajero.NUMASI = pasajero.NUMASI_ORI;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeIDA;
                        listPasajero.Add(entidadPasajero);

                        //REGISTRAMOS LA VUELTA
                        entidadPasajero.NUMASI = pasajero.NUMASI_DES;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeVUELTA;
                        listPasajero.Add(entidadPasajero);
                    }
                }
                else
                {

                    listPasajero = (List<PASAJERO>)Session[Sesiones.sessionListaPasajeros];
                    if (string.IsNullOrWhiteSpace(pasajero.NUMASI_DES)) {
                        entidadPasajero.NUMASI = pasajero.NUMASI_ORI;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeIDA;
                        listPasajero.Add(entidadPasajero);
                    } else {
                        //REGISTRAMOS LA IDA
                        entidadPasajero.NUMASI = pasajero.NUMASI_ORI;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeIDA;
                        listPasajero.Add(entidadPasajero);

                        //REGISTRAMOS LA VUELTA
                        entidadPasajero.NUMASI = pasajero.NUMASI_DES;
                        entidadPasajero.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeVUELTA;
                        listPasajero.Add(entidadPasajero);
                    }
                    
                }
                Session[Sesiones.sessionListaPasajeros] = listPasajero;
                return Json(new { Success = true, Message = "Registro el pasajero satisfactoriamente" });
            }
            catch (Exception) {
                return Json(new { Success = false, Message = "Ocurrio un error al registrar al pasajero" });
            }
        }

        #endregion
    }
}