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
    public class PersonalController : Controller
    {
        IPersonalLogic _personalLogic;
        IConsultaPersonalLogic _consultaPersonalLogic;
        IUsuarioLogic _usuarioLogic;
        public PersonalController()
        {
            this._personalLogic = Configuration.Unity.Container.Resolve<IPersonalLogic>();
            this._consultaPersonalLogic = Configuration.Unity.Container.Resolve<IConsultaPersonalLogic>();
            this._usuarioLogic = Configuration.Unity.Container.Resolve<IUsuarioLogic>();
        }

        // GET: Personal
        public ActionResult Index()
        {
            var model = new PersonalModel();
            var lista = _consultaPersonalLogic.ListarPersonal("" , "");
            model.LIST_PERSONAL = model.Personal.castPersonalType(lista.ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PersonalModel filtros)
        {
            var model = new PersonalModel();

            var entidad = Mapper.Map<PersonalModels, SRV_PERSONAL>(filtros.Personal);
            var usuario = Mapper.Map<UsuarioModels, SRV_USUARIO>(filtros.Personal.Usuario);

            var lista = _consultaPersonalLogic.ListarPersonal(entidad.DNIPER, usuario.LOGUSU);
            model.LIST_PERSONAL = model.Personal.castPersonalType(lista.ToList());
            return View(model);
        }

        public PartialViewResult RegistroPersonal(int? id)
        {
            var model = new PersonalModels();
            model.ESTREG = "1";
            if (id.HasValue)
            {
                var personal = _personalLogic.BuscarPorId(id.Value);
                var usuario = _usuarioLogic.BuscarPorId(personal.CODUSU.Value);
                model.CODPER = personal.CODPER;
                model.NOMPER = personal.NOMPER;
                model.APEPER = personal.APEPER;
                model.DNIPER = personal.DNIPER;
                model.Usuario.CODUSU = usuario.CODUSU;
                model.Usuario.LOGUSU = usuario.LOGUSU;

                return PartialView("_EditarPersonal", model);
            }

            return PartialView("_RegistroPersonal", model);
        }

        public JsonResult GrabarPersonal(PersonalModels personal)
        {
            var entidad = Mapper.Map<PersonalModels, SRV_PERSONAL>(personal);
            var usuario = Mapper.Map<UsuarioModels, SRV_USUARIO>(personal.Usuario);
            entidad.ESTREG = "1";
            usuario.ESTREG = "1";
            var result = entidad.CODPER > 0 ? _personalLogic.ActualizarPersonalUsuario(entidad, usuario) : _personalLogic.RegistrarPersonalUsuario(entidad, usuario);
            return Json(result);
        }

        public JsonResult EliminarPersonal(int id)
        {
            var result = _personalLogic.EliminarPersonal(id);
            return Json(result);
        }
    }
}