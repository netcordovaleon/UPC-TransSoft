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
    public class TipoTarjetaController : Controller
    {

        ITipoTarjetaLogic _tipoTarjetaLogic;
        public TipoTarjetaController()
        {
            this._tipoTarjetaLogic = Configuration.Unity.Container.Resolve<ITipoTarjetaLogic>();
        }

        // GET: MedioPago
        public ActionResult Index()
        {
            var model = new TipoTarjetaModel();
            var lista = this._tipoTarjetaLogic.ListarTiposTarjeta(new SRV_TIPO_TARJETA());
            model.LIST_TARJETA = model.TipoTarjeta.castTipoTarjetaType(lista.ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TipoTarjetaModel filtros)
        {
            var model = new TipoTarjetaModel();

            var entidad = Mapper.Map<TipoTarjetaModels, SRV_TIPO_TARJETA>(filtros.TipoTarjeta);

            var lista = this._tipoTarjetaLogic.ListarTiposTarjeta(entidad);
            model.LIST_TARJETA = model.TipoTarjeta.castTipoTarjetaType(lista.ToList());
            return View(model);
        }

        public PartialViewResult RegistroTipoTarjeta(int? id)
        {
            var model = new TipoTarjetaModels();
            model.ESTREG = "1";
            if (id.HasValue)
            {
                var TipoTarjeta = _tipoTarjetaLogic.BuscarPorId(id.Value);
                model.CODTIPTAR = TipoTarjeta.CODTIPTAR;
                model.NOMTIPTAR = TipoTarjeta.NOMTIPTAR;
                model.MEDPAG = TipoTarjeta.MEDPAG;
                model.ESTREG = TipoTarjeta.ESTREG;

                return PartialView("_EditarTipoTarjeta", model);
            }

            return PartialView("_RegistroTipoTarjeta", model);
        }

        public JsonResult GrabarTipoTarjeta(TipoTarjetaModels tipoTarjeta)
        {
            var entidad = Mapper.Map<TipoTarjetaModels, SRV_TIPO_TARJETA>(tipoTarjeta);
            var result = entidad.CODTIPTAR > 0 ? _tipoTarjetaLogic.ActualizarTipoTarjeta(entidad) : _tipoTarjetaLogic.RegistrarTipoTarjeta(entidad);
            return Json(result);
        }

        public JsonResult EliminarTipoTarjeta(int id)
        {
            var result = _tipoTarjetaLogic.EliminarTipoTarjeta(id);
            return Json(result);
        }
    }
}