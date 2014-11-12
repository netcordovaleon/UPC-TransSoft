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

namespace UPC.TS.Web.Controllers
{
    public class HomeController : Controller
    {

        IContactenosLogic _contactenosLogic;
        ITarifasLogic _tarifasLogic;
        public HomeController() {
            this._contactenosLogic = Configuration.Unity.Container.Resolve<IContactenosLogic>();
            this._tarifasLogic = Configuration.Unity.Container.Resolve<ITarifasLogic>(); 
        }
        public ActionResult Index()
        {
            var model = new FiltrosReservaModels();
            var origenes = _tarifasLogic.ListarOrigen();
            var destinos = _tarifasLogic.ListarDestino();
            model.LIST_ORI = (from c in origenes select new SelectListItem { Text = c.ORITAR, Value = c.ORITAR });
            model.LIST_DES = (from c in destinos select new SelectListItem { Text = c.DESTAR, Value = c.DESTAR });
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}