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
        public ActionResult Index()
        {
            

            var entidad = new ContactenosModels();
            entidad.nomcompcon = "Luis Alex Cordova Leon";
            var entity = Mapper.Map<ContactenosModels, contactenos>(entidad);
            IContactenosLogic _contactenosLogic = Configuration.Unity.Container.Resolve<IContactenosLogic>();
            //_contactenosLogic.GrabarContacto(entity);
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