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
    public class DescuentoController : Controller
    {
        IPromocionLogic _descuentoLogic;
        public DescuentoController()
        {
            this._descuentoLogic = Configuration.Unity.Container.Resolve<IPromocionLogic>();
        }

        // GET: Descuento
        public ActionResult Index()
        {
            return View();
        }
    }
}