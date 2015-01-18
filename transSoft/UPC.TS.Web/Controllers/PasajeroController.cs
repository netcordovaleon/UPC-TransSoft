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
    public class PasajeroController : Controller
    {
        IPasajeroLogic _pasajeroLogic;
        IConsultaReservaLogic _consultaReservaLogic;
        public PasajeroController() {
            this._consultaReservaLogic = Configuration.Unity.Container.Resolve<IConsultaReservaLogic>();
            this._pasajeroLogic = Configuration.Unity.Container.Resolve<IPasajeroLogic>();
        }
        //
        // GET: /Pasajero/
        public ActionResult BuscarReservas()
        {
            var model = new ReservaModels();
            var listaReservas = _consultaReservaLogic.ListarReservaPorUsuario(Session[Sesiones.sessionUsuarioLog].ToString());
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        [HttpPost]
        public ActionResult BuscarReservas(ReservaModels model) {
            var listaReservas = new List<SRV_VW_RESERVAS>();
            if (!model.filtros.CODRES.HasValue)
                listaReservas = _consultaReservaLogic.ListarReservaPorUsuario(Session[Sesiones.sessionUsuarioLog].ToString()).ToList();
            else
                listaReservas = _consultaReservaLogic.ListarReservaPorUsuarioyReserva(model.filtros.CODRES.Value, Session[Sesiones.sessionUsuarioLog].ToString()).ToList();
            model.listaReservasVista = model.castReservaVistaType((List<SRV_VW_RESERVAS>)listaReservas);
            return View(model);
        }

        public JsonResult ListarPasajeroPorReserva(int CODRES) {
            var model = new ReservaModels();

            var lista = model.castPasajerosType(_pasajeroLogic.ListarPasajeroPorReserva(CODRES).ToList());
            return Json(lista);
        }

        public PartialViewResult ModPasajero(int CODPAS) { 
            var model = new PasajeroModels();
            var result = _pasajeroLogic.BuscarPorId(CODPAS);
            var entidad = new PasajeroModels() { 
                CODPAS = result.CODPAS,
                CODRES = result.CODRES,
                NOMPAS = result.NOMPAS,
                APEPPAS = result.APEPPAS,
                APEMPAS = result.APEMPAS,
                DIRPAS = result.DIRPAS,
                NUMDOC = result.NUMDOC,
                TIPDOC = result.TIPDOC,
                SEXPAS = result.SEXPAS,
                TELPAS = result.TELPAS,
                CELPAS = result.CELPAS
            };
            model = entidad;
            return PartialView("_ModPasajero", model);
        }

        public JsonResult GrabarPasajero(PasajeroModels model) {
            var entidad = Mapper.Map<PasajeroModels, SRV_PASAJERO>(model);
            var result = _pasajeroLogic.GrabarPasajeros(entidad);
            return Json(result);
        }
	}
}