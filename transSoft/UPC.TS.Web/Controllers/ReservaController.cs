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
        IConsultaAsientosORILogic _consultaAsientosORILogic;
        IConsultaAsientosDESLogic _consultaAsientosDESLogic;
        IConsultaReservaLogic _consultaReservaLogic;
        IPasajeroLogic _pasajeroLogic;
        ITipoTarjetaLogic _tipoTarjetaLogic;

        public ReservaController()
        {
            
            this._consultaProgramacionLogic = Configuration.Unity.Container.Resolve<IConsultaProgramacionLogic>();
            this._usuarioLogic = Configuration.Unity.Container.Resolve<IUsuarioLogic>();
            this._reservaLogic = Configuration.Unity.Container.Resolve<IReservaLogic>();
            this._clienteLogic = Configuration.Unity.Container.Resolve<IClienteLogic>();
            this._consultaAsientosORILogic = Configuration.Unity.Container.Resolve<IConsultaAsientosORILogic>();
            this._consultaAsientosDESLogic = Configuration.Unity.Container.Resolve<IConsultaAsientosDESLogic>();
            this._consultaReservaLogic = Configuration.Unity.Container.Resolve<IConsultaReservaLogic>();
            this._pasajeroLogic = Configuration.Unity.Container.Resolve<IPasajeroLogic>();
            this._tipoTarjetaLogic = Configuration.Unity.Container.Resolve<ITipoTarjetaLogic>();
        }

        #endregion

        #region CONSULTA DE PROGRAMACION
        // GET: /Reserva/
        public ActionResult Programacion(FiltrosReservaModels filtros)
        {
            var model = new ReservaModels();

            #region PROGRAMACION PARA ORIGEN
            var listadoProgramacion = _consultaProgramacionLogic.ListarProgramacion(filtros.DESORI, filtros.DESDES, filtros.FECSAL);
            model.filtros = filtros;
            model.listaProgramacion = model.castProgramacionType((List<SRV_VW_CONSULTA_PROGRAMACION>)listadoProgramacion);
            #endregion

            #region PROGRAMACION PARA DESTINO
            if (filtros.TIPVIA.Equals("I_V")) { 
                var listadoProgramacionDestino = _consultaProgramacionLogic.ListarProgramacion(filtros.DESDES, filtros.DESORI, filtros.FECRET);
                model.listaProgramacionDestino = model.castProgramacionType((List<SRV_VW_CONSULTA_PROGRAMACION>)listadoProgramacionDestino);
            }
            #endregion


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
            var entidad = Mapper.Map<UsuarioModels, SRV_USUARIO>(model.usuario);
            var result = _usuarioLogic.IngresarSistema(entidad);
            if (result.Success) {
                Session[Sesiones.sessionUsuarioLog] = model.usuario.LOGUSU;
            }
            return Json(result);
        }

        public JsonResult RegistrarUsuario(ReservaUsuarioModels model) {
            var usuario = Mapper.Map<UsuarioModels, SRV_USUARIO>(model.usuario);
            var cliente = new SRV_CLIENTE(){  CORCLI = usuario.LOGUSU };
            var result = _usuarioLogic.AgregarUsuarioReserva(usuario, cliente);
            if (result.Success) {
                Session[Sesiones.sessionUsuarioLog] = model.usuario.LOGUSU;
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
            var reserva = new SRV_RESERVA() { 
                 CODPRO = CODPRO.Value,
                 FECRES = DateTime.Now,
                 ESTTRAN = Infraestructure.Enum.EstadoTranReserva.RESERVADO,
                 CODCLI = _clienteLogic.ObtenerUsuarioPorCorreo(Session[Sesiones.sessionUsuarioLog].ToString()).CODCLI,
                 ESTREG = "1"
            };
            if (CODPRODES.HasValue) {
                if (CODPRODES.Value != 0)
                    reserva.CODPRODES = CODPRODES.Value; 
            }
            var result = _reservaLogic.RegistrarReserva((List<SRV_PASAJERO>)Session[Sesiones.sessionListaPasajeros], reserva);
            return Json(result);
            
        }

        public ActionResult RegistrarAsientoPas(PasajeroModels pasajero) {
            try
            {
                var entidadPasajero = Mapper.Map<PasajeroModels, SRV_PASAJERO>(pasajero);
                var entidadPasajeroVuelta = Mapper.Map<PasajeroModels, SRV_PASAJERO>(pasajero);
                List<SRV_PASAJERO> listPasajero;
                if (Session[Sesiones.sessionListaPasajeros] == null)
                {
                    listPasajero = new List<SRV_PASAJERO>();
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
                        entidadPasajeroVuelta.NUMASI = pasajero.NUMASI_DES;
                        entidadPasajeroVuelta.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeVUELTA;
                        listPasajero.Add(entidadPasajeroVuelta);
                    }
                }
                else
                {

                    listPasajero = (List<SRV_PASAJERO>)Session[Sesiones.sessionListaPasajeros];
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
                        entidadPasajeroVuelta.NUMASI = pasajero.NUMASI_DES;
                        entidadPasajeroVuelta.TIPVIA = Infraestructure.Enum.TipoViaje.ViajeVUELTA;
                        listPasajero.Add(entidadPasajeroVuelta);
                    }
                    
                }
                Session[Sesiones.sessionListaPasajeros] = listPasajero;
                return Json(new { Success = true, Message = "Registro el pasajero satisfactoriamente", TypeResponse = Infraestructure.Constantes.TypeResponse.success.ToString(), Title = Infraestructure.Constantes.TitleResponse.success, Data = listPasajero });
            }
            catch (Exception) {
                Session[Sesiones.sessionListaPasajeros] = null;
                return Json(new { Success = false, Message = "Ocurrio un error al registrar al pasajero", TypeResponse = Infraestructure.Constantes.TypeResponse.error.ToString(), Title = Infraestructure.Constantes.TitleResponse.error });
            }
        }

        public JsonResult EliminarAsientoPas(string DNI) {
            try
            {
                var listPasajero = (List<SRV_PASAJERO>)Session[Sesiones.sessionListaPasajeros];
                var item = listPasajero.Where(c => c.NUMDOC == DNI).First();
                listPasajero.Remove(item);
                Session[Sesiones.sessionListaPasajeros] = listPasajero;
                return Json(new { Success = true, Message = "Elimino el pasajero satisfactoriamente", TypeResponse = Infraestructure.Constantes.TypeResponse.success.ToString(), Title = Infraestructure.Constantes.TitleResponse.success, Data = listPasajero });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Ocurrio un error al eliminar el pasajero", TypeResponse = Infraestructure.Constantes.TypeResponse.error.ToString(), Title = Infraestructure.Constantes.TitleResponse.error });
            }
        }

        public JsonResult ListarAsientosReservadosORI(int CODPRO) {
            var result = _consultaAsientosORILogic.ListarAsientosORI(CODPRO);
            return Json(result);
        }

        public JsonResult ListarAsientosReservadosDES(int CODPRO)
        {
            var result = _consultaAsientosDESLogic.ListarAsientosDES(CODPRO);
            return Json(result);
        }

        #endregion

        #region ANULACION DE RESERVAS

        public ActionResult AnularReserva()
        {
            var model = new ReservaModels();
            var listaReservas = _consultaReservaLogic.ListarReservaPorUsuario(Session[Sesiones.sessionUsuarioLog].ToString());
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        [HttpPost]
        public ActionResult AnularReserva(ReservaModels model)
        {
            var listaReservas = new List<SRV_VW_RESERVAS>();
            if (!model.filtros.CODRES.HasValue)
                listaReservas = _consultaReservaLogic.ListarReservaPorUsuario(Session[Sesiones.sessionUsuarioLog].ToString()).ToList();
            else
                listaReservas = _consultaReservaLogic.ListarReservaPorUsuarioyReserva(model.filtros.CODRES.Value,Session[Sesiones.sessionUsuarioLog].ToString()).ToList();
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        public JsonResult AnularReservaActiva(int CODRES) {
            var result = _reservaLogic.AnularReserva(CODRES);
            return Json(result);
        }

        #endregion

        public ActionResult PagarReservas()
        {
            var model = new ReservaModels();
            var listaReservas = _consultaReservaLogic.ObtenerReservasUsuario(Session[Sesiones.sessionUsuarioLog].ToString());
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        [HttpPost]
        public ActionResult BuscarReservas(ReservaModels model)
        {
            var listaReservas = new List<SRV_VW_RESERVAS>();
            if (!model.filtros.CODRES.HasValue)
                listaReservas = _consultaReservaLogic.ObtenerReservasUsuario(Session[Sesiones.sessionUsuarioLog].ToString()).ToList();
            else
                listaReservas = _consultaReservaLogic.ObtenerReservasUsuario(Session[Sesiones.sessionUsuarioLog].ToString(), model.filtros.CODRES.Value).ToList();
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        public ActionResult PagarReserva(int id)
        {
            var model = new PagarReservaModels();

            var reserva = this._reservaLogic.BuscarPorId(id);

            var pasajeros = this._pasajeroLogic.ListarPasajeroPorReserva(reserva.CODRES);

            var rutas = new List<SRV_VW_CONSULTA_PROGRAMACION>();

            rutas.Add(this._consultaProgramacionLogic.BuscarPorId(reserva.CODPRO.Value));
            if(reserva.CODPRODES.HasValue)
                rutas.Add(this._consultaProgramacionLogic.BuscarPorId(reserva.CODPRODES.Value));

            model.CODRES = reserva.CODRES;
            model.FECRES = reserva.FECRES.Value.ToString("dd/MM/yyyy");
            model.Compra.CODRES = reserva.CODRES;
            model.Compra.FECCOM = DateTime.Now;
            model.listaPasajeros = model.castPasajerosType(pasajeros);
            model.listaProgramacion = model.castProgramacionType(rutas);

            var numeroPasajeros = reserva.CODPRODES.HasValue ? pasajeros.Count() / 2 : pasajeros.Count();

            var totalPasaje = rutas.Sum(c => c.PRETAR.Value);

            model.Compra.MONTOT = totalPasaje * numeroPasajeros;
            model.Compra.VALIGV = Math.Round(model.Compra.MONTOT.Value * (decimal)(0.18), 2);
            model.Compra.SUBTOT = model.Compra.MONTOT - model.Compra.VALIGV;

            var lista = this._tipoTarjetaLogic.ListarTodo();
            model.Tarjeta.ESTREG = "1";
            model.Tarjeta.LIST_TIPTAR = model.Tarjeta.castTipoTarjetaType(lista.ToList());

            return View(model);
        }

        public JsonResult GrabarCompra(PagarReservaModels pagarreserva)
        {
            var codReserva = pagarreserva.CODRES;
            var compra = Mapper.Map<CompraModels, SRV_COMPRA>(pagarreserva.Compra);
            var tarjeta = Mapper.Map<TarjetaModels, SRV_TARJETA>(pagarreserva.Tarjeta);
            var result = this._reservaLogic.PagarReserva(codReserva, tarjeta, compra);
            return Json(result);
        }
    }
}