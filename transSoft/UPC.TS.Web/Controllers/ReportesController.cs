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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace UPC.TS.Web.Controllers
{
    public class ReportesController : Controller
    {
        ICompraLogic _compraLogic;

        public ReportesController()
        {
            this._compraLogic = Configuration.Unity.Container.Resolve<ICompraLogic>();
        }

        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProyeccionDeVentas()
        {
            var model = new ReporteVentaModel();
            model.Reporte.FECINI = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("dd/MM/yyyy");
            model.Reporte.FECFIN = (new DateTime(DateTime.Now.Year, 12, 31)).ToString("dd/MM/yyyy");
            return View(model);
        }

        [HttpPost]
        public ActionResult ProyeccionDeVentas(ReporteVentaModel filtros)
        {
            var model = new ReporteVentaModel();
            
            var lista = this._compraLogic.ListarVentas(DateTime.ParseExact(filtros.Reporte.FECINI, "dd/MM/yyyy", null), DateTime.ParseExact(filtros.Reporte.FECFIN, "dd/MM/yyyy", null));
            var listado = new List<ReporteVentaModels>();
            if(filtros.Reporte.TIPBUS.Equals("M"))
            {
                listado = lista.Select(c => new ReporteVentaModels() { 
                                                                        FECGRP = int.Parse(string.Format("{0}{1}", c.FECCOM.Value.Year,  c.FECCOM.Value.Month.ToString("00"))), 
                                                                        DESREP = c.FECCOM.Value.ToString("yyyy - MM"),
                                                                        MONTOT = c.MONTOT.Value, 
                                                                        TOTCOM = 1}).ToList();
                listado = listado.GroupBy(c => c.FECGRP).Select(c => new ReporteVentaModels() { 
                                                                        FECGRP = c.Key, 
                                                                        DESREP = c.First().DESREP, 
                                                                        MONTOT = c.Sum(s => s.MONTOT), 
                                                                        TOTCOM = c.Sum(s => s.TOTCOM) }).ToList();

                model.LIST_VENTA = listado.ToList();
            }
            else
            {
                listado = lista.Select(c => new ReporteVentaModels() { 
                                                                        FECGRP = c.FECCOM.Value.Year, 
                                                                        MONTOT = c.MONTOT.Value, 
                                                                        TOTCOM = 1 }).ToList();
                listado = listado.GroupBy(c => c.FECGRP).Select(c => new ReporteVentaModels() { 
                                                                        FECGRP = c.Key, 
                                                                        DESREP = c.Key.ToString(), 
                                                                        MONTOT = c.Sum(s => s.MONTOT), 
                                                                        TOTCOM = c.Sum(s => s.TOTCOM) }).ToList();

                model.LIST_VENTA = listado.ToList();
            }

            if (filtros.GENREP.Equals("E"))
            {

                var ventas = new System.Data.DataTable("ventas");
                ventas.Columns.Add("Descripcion", typeof(string));
                ventas.Columns.Add("Nro_Compras", typeof(decimal));
                ventas.Columns.Add("Monto_Total_Compras", typeof(decimal));
                foreach (var item in listado)
	            {
                    ventas.Rows.Add(item.DESREP, item.MONTOT, item.TOTCOM);
	            }

                var grid = new GridView();
                grid.DataSource = ventas;
                grid.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
                Response.ContentType = "application/ms-excel";

                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

                return View("ProyeccionDeVentas");
            }

            return View(model);
        }
    }
}