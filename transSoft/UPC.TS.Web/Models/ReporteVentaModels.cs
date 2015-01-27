using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;

namespace UPC.TS.Web.Models
{
    public class ReporteVentaModel
    {
        public string GENREP { get; set; }
        public ReporteVentaModels Reporte { get; set; }
        public List<ReporteVentaModels> LIST_VENTA { get; set; }
        public List<SelectListItem> LIST_TIPBUS { get; set; }
        public ReporteVentaModel()
        {
            this.LIST_VENTA = new List<ReporteVentaModels>();
            this.Reporte = new ReporteVentaModels();
            this.LIST_TIPBUS = new List<SelectListItem>();
            this.LIST_TIPBUS.Add(new SelectListItem() { Value = "M", Text = "Mensual" });
            this.LIST_TIPBUS.Add(new SelectListItem() { Value = "A", Text = "Anual" });
        }
    }
    public class ReporteVentaModels
    {
        public decimal FECGRP { get; set; }
        public string DESREP { get; set; }
        public decimal TOTCOM { get; set; }
        public decimal MONTOT { get; set; }
        [Display(Name="Fehca Inicial")]
        public string FECINI { get; set; }
        [Display(Name="Fecha Final")]
        public string FECFIN { get; set; }
        [Display(Name = "Tipo de Búsqueda")]
        public string TIPBUS { get; set; }
    }

    public class ReporteVentaRdl
    {
        public List<ReporteVentaModels> ReporteVentaDataSet()
        {
            return null;
        }
    }
}