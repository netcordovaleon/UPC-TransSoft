using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.TS.Web.Models
{
    public class FiltrosReservaModels
    {
        [Display(Name = "Origen")]
        public string DESORI { get; set; }
        [Display(Name="Destino")]
        public string DESDES { get; set; }
        [Display(Name = "Fecha Salida")]
        public string FECSAL { get; set; }
        [Display(Name = "Fecha Retorno")]
        public string FECRET { get; set; }
        public string TIPVIA { get; set; }
        public IEnumerable<SelectListItem> LIST_ORI { get; set; }
        public IEnumerable<SelectListItem> LIST_DES { get; set; }

        public FiltrosReservaModels() {
            this.LIST_DES = new List<SelectListItem>();
            this.LIST_ORI = new List<SelectListItem>();
        }
    }
}