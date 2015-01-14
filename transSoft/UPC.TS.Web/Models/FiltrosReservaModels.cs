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
        [Display(Name = "Codigo Reserva")]
        public int? CODRES { get; set; }

        [Display(Name = "Origen")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DESORI { get; set; }
        [Display(Name="Destino")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DESDES { get; set; }
        [Display(Name = "Fecha Salida")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FECSAL { get; set; }
        [Display(Name = "Fecha Retorno")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FECRET { get; set; }
        [Required(ErrorMessage="Este campo es obligatorio")]
        public string TIPVIA { get; set; }
        public IEnumerable<SelectListItem> LIST_ORI { get; set; }
        public IEnumerable<SelectListItem> LIST_DES { get; set; }

        public FiltrosReservaModels() {
            this.LIST_DES = new List<SelectListItem>();
            this.LIST_ORI = new List<SelectListItem>();
        }
    }
}