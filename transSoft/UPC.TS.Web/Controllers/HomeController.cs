using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement;
using UPC.TS.DataImplement.Infraestructura;
namespace UPC.TS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IUnitOfWork un = new UnitOfWork();
            IContactenos xx = new ContactenosData(un);
            var modelo = new contactenos();
            modelo.nomcompcon = "ssss";
            xx.grabarContactenos(modelo);
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