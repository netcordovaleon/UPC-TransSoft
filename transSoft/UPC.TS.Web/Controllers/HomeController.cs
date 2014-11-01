using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
using UPC.TS.BusinessLogic;
using UPC.TS.BusinessContract;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UPC.TS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entidad = new contactenos();
            entidad.nomcompcon = "Luis Alex Cordova Leon";
            IContactenosLogic _contactenosLogic = Configuration.Unity.Container.Resolve<IContactenosLogic>();
            _contactenosLogic.GrabarContacto(entidad);
            return View();
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