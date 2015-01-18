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
    public class TarifaController : Controller
    {
        ITarifasLogic _tarifaLogic;
        public TarifaController()
        {
            this._tarifaLogic = Configuration.Unity.Container.Resolve<ITarifasLogic>();
        }
        // GET: Tarifa
        public ActionResult Index()
        {
            var origenes = _tarifaLogic.ListarOrigen();
            var destinos = _tarifaLogic.ListarDestino();
            var tarifasRegistradas = _tarifaLogic.ListarTarifas();
            var model = new TarifasModel();
            model.tarifa.LIST_ORI = (from c in origenes select new SelectListItem() { Text = c.ORITAR, Value = c.ORITAR }).ToList<SelectListItem>();
            model.tarifa.LIST_DES = (from c in destinos select new SelectListItem() { Text = c.DESTAR, Value = c.DESTAR }).ToList<SelectListItem>();
            model.LIST_TARIFA = model.tarifa.castTarifaType(tarifasRegistradas.ToList()) ;


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TarifasModel filtros) {
            var origenes = _tarifaLogic.ListarOrigen();
            var destinos = _tarifaLogic.ListarDestino();
            var model = new TarifasModel();
            var entidad = Mapper.Map<TarifaModels, SRV_TARIFA>(filtros.tarifa);
            model.tarifa.LIST_ORI = (from c in origenes select new SelectListItem() { Text = c.ORITAR, Value = c.ORITAR }).ToList<SelectListItem>();
            var lista = _tarifaLogic.ListarTarifaFiltro(entidad);
            model.tarifa.LIST_DES = (from c in destinos select new SelectListItem() { Text = c.DESTAR, Value = c.DESTAR }).ToList<SelectListItem>();
            model.LIST_TARIFA = model.tarifa.castTarifaType(lista.ToList());
            return View(model);
        }

        public PartialViewResult RegistroTarifa(int? id) {
            var model = new TarifaModels();

            model.LIST_ORI.Add(new SelectListItem() { Text = "AREQUIPA", Value = "AREQUIPA" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "ANCASH", Value = "ANCASH" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "APURIMAC", Value = "APURIMAC" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "LIMA", Value = "LIMA" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "ICA", Value = "ICA" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "PUNO", Value = "PUNO" });
            model.LIST_ORI.Add(new SelectListItem() { Text = "CUZCO", Value = "CUZCO" });

            model.LIST_DES.Add(new SelectListItem() { Text = "AREQUIPA", Value = "AREQUIPA" });
            model.LIST_DES.Add(new SelectListItem() { Text = "ANCASH", Value = "ANCASH" });
            model.LIST_DES.Add(new SelectListItem() { Text = "APURIMAC", Value = "APURIMAC" });
            model.LIST_DES.Add(new SelectListItem() { Text = "LIMA", Value = "LIMA" });
            model.LIST_DES.Add(new SelectListItem() { Text = "ICA", Value = "ICA" });
            model.LIST_DES.Add(new SelectListItem() { Text = "PUNO", Value = "PUNO" });
            model.LIST_DES.Add(new SelectListItem() { Text = "CUZCO", Value = "CUZCO" });

            if (id.HasValue)
            {
                var tarifa = _tarifaLogic.BuscarPorId(id.Value);
                model.CODTAR = tarifa.CODTAR;
                model.PRETAR = tarifa.PRETAR;
                model.ORITAR = tarifa.ORITAR;
                model.DESTAR = tarifa.DESTAR;
                model.CODESTTAR = tarifa.CODESTTAR;
                return PartialView("_RegistroTarifa", model);
            }
            else {
                return PartialView("_RegistroTarifa", model);
            }
        }

        public JsonResult GrabarTarifa(TarifaModels tarifa)
        {
            var entidad = Mapper.Map<TarifaModels, SRV_TARIFA>(tarifa);
            var result = _tarifaLogic.GrabarTarifa(entidad);
            return Json(result);
        }

        public JsonResult EliminarTarifa(int id) {
            var result = _tarifaLogic.EliminarTarifa(id);
            return Json(result);
        }

        public JsonResult PublicarTarifa(int id) {
            var entidad = _tarifaLogic.BuscarPorId(id);
            entidad.CODESTTAR = "P";
            var result = _tarifaLogic.GrabarTarifa(entidad);
            return Json(result);
        }
    }
}