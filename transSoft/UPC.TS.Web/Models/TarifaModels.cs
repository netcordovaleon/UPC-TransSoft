using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
namespace UPC.TS.Web.Models
{

    public class TarifasModel {
        public TarifaModels tarifa { get; set; }
        public List<TarifaModels> LIST_TARIFA { get; set; }
        public TarifasModel() { 
            this.LIST_TARIFA = new List<TarifaModels>();
            this.tarifa = new TarifaModels();
        }
    }

    public class TarifaModels
    {
        public int CODTAR { get; set; }

        [Display(Name = "Origen")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string ORITAR { get; set; }
        [Display(Name = "Destino")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DESTAR { get; set; }
        [Display(Name = "Precio")]
        [RegularExpression(@"^\d+(?:\.\d{1,2})?$", ErrorMessage = "Ingrese un número valido ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<decimal> PRETAR { get; set; }
        public string ESTREG { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CODESTTAR { get; set; }
        public Nullable<int> CODTIPSER { get; set; }

        public List<SelectListItem> LIST_ORI { get; set; }
        public List<SelectListItem> LIST_DES { get; set; }
        public List<SelectListItem> LIST_ESTTAR { get; set; }

        public List<TarifaModels> castTarifaType(List<SRV_TARIFA> lista)
        {
            var listadoFinal = new List<TarifaModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new TarifaModels()
                {
                    CODTAR = item.CODTAR,
                    ORITAR = item.ORITAR,
                    DESTAR = item.DESTAR,
                    PRETAR = item.PRETAR              ,
                    CODESTTAR = item.CODESTTAR
                });
            }
            return listadoFinal;
        }

        public TarifaModels() {
            this.LIST_ORI = new List<SelectListItem>();
            this.LIST_DES = new List<SelectListItem>();
            this.LIST_ESTTAR = new List<SelectListItem>();

            this.LIST_ESTTAR.Add(new SelectListItem() { Text = "Publicado", Value="P" });
            this.LIST_ESTTAR.Add(new SelectListItem() { Text = "No publicar", Value = "N" });
            
        }



    }
}