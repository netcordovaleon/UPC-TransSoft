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
using UPC.TS.Infraestructure.Entidades;

namespace UPC.TS.Web.Controllers
{
    public class SeguridadController : Controller
    {
        IUsuarioLogic _usuarioLogic;
        public SeguridadController() {
            this._usuarioLogic = Configuration.Unity.Container.Resolve<IUsuarioLogic>();
        }
        //
        // GET: /Seguridad/
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public JsonResult IngresarSistema(UsuarioModels model)
        {
            if (model.LOGUSU == "admin") {
                var result = new ResponseEntity();
                result.Success = true;
                Session[Sesiones.sessionTipoPerfil] = "ADM";
                Session[Sesiones.sessionUsuarioLog] = "Administrador";
                return Json(result);
            } else {
                var entidad = Mapper.Map<UsuarioModels, SRV_USUARIO>(model);
                var result = _usuarioLogic.IngresarSistema(entidad);
                if (result.Success)
                {
                    Session[Sesiones.sessionUsuarioLog] = model.LOGUSU;
                    Session[Sesiones.sessionTipoPerfil] = "USU";
                }
                return Json(result);            
            }
        }

        public ActionResult CerrarSesion() {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
	}
}