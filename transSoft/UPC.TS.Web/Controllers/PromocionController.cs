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
    public class PromocionController : Controller
    {

        IPromocionLogic _promocionLogic;
        public PromocionController()
        {
            this._promocionLogic = Configuration.Unity.Container.Resolve<IPromocionLogic>();

        }
        // GET: Promocion
        public ActionResult Index()
        {
            var model = new PromocionModel();
            var lista = _promocionLogic.ListarPromocion();
            model.LIST_PROMOCIONES = model.Promocion.castPromocionType(lista.ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PromocionModel filtros)
        {
            var model = new PromocionModel();
            
            var entidad = new SRV_PROMOCION();
            entidad.DESPROM = filtros.Promocion.DESPROM;
            if (!string.IsNullOrEmpty(filtros.Promocion.FECFIN)) entidad.FECFIN = DateTime.ParseExact(filtros.Promocion.FECINI, "dd/MM/yyyy", null);
            if (!string.IsNullOrEmpty(filtros.Promocion.FECINI)) entidad.FECINI = DateTime.ParseExact(filtros.Promocion.FECINI, "dd/MM/yyyy", null);

            var lista = _promocionLogic.ListarPromocionFiltro(entidad);
            model.LIST_PROMOCIONES = model.Promocion.castPromocionType(lista.ToList());
            return View(model);
        }

        public PartialViewResult RegistroPromocion(int? id)
        {
            var model = new PromocionModels();
            model.ESTREG = "1";
            if (id.HasValue)
            {
                var promocion = _promocionLogic.BuscarPorId(id.Value);
                model.CODPROM = promocion.CODPROM;
                model.DESPROM = promocion.DESPROM;
                model.PORDESC = promocion.PORDESC;
                model.FECINI = promocion.FECINI.HasValue ? promocion.FECINI.Value.ToString("dd/MM/yyyy") : "";
                model.FECFIN = promocion.FECFIN.HasValue ? promocion.FECFIN.Value.ToString("dd/MM/yyyy") : "";
            }

            return PartialView("_RegistroPromocion", model);
        }

        public JsonResult GrabarPromocion(PromocionModels promocion)
        {
            var entidad = new SRV_PROMOCION() { 
                CODPROM = promocion.CODPROM,
                ESTREG = "1",
                FECINI = DateTime.ParseExact(promocion.FECINI, "dd/MM/yyyy", null),
                FECFIN = DateTime.ParseExact(promocion.FECFIN, "dd/MM/yyyy", null),
                DESPROM = promocion.DESPROM,
                PORDESC = promocion.PORDESC
            };
            var result = _promocionLogic.GrabarPromocion(entidad);
            return Json(result);
        }

        public JsonResult EliminarPromocion(int id)
        {
            var result = _promocionLogic.EliminarPromocion(id);
            return Json(result);
        }
    }
}