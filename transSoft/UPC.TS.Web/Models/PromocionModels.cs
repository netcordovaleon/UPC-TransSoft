using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;

namespace UPC.TS.Web.Models
{
    public class PromocionModel
    {
        public PromocionModels Promocion { get; set; }
        public List<PromocionModels> LIST_PROMOCIONES { get; set; }
        public PromocionModel()
        {
            this.LIST_PROMOCIONES = new List<PromocionModels>();
            this.Promocion = new PromocionModels();
        }
    }

    public class PromocionModels
    {
        public int CODPROM { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FECINI { get; set; }
        [Display(Name = "Fecha Termino")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FECFIN { get; set; }
        [RegularExpression(@"^\d+(?:\.\d{1,2})?$", ErrorMessage = "Ingrese un número valido ")]
        [Display(Name = "% Dscto")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<decimal> PORDESC { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DESPROM { get; set; }
        public string ESTREG { get; set; }

        public List<PromocionModels> castPromocionType(List<SRV_PROMOCION> lista)
        {
            var listadoFinal = new List<PromocionModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new PromocionModels()
                {
                    CODPROM = item.CODPROM,
                    DESPROM = item.DESPROM,
                    PORDESC = item.PORDESC,
                    FECINI = item.FECINI.HasValue ? item.FECINI.Value.ToString("dd/MM/yyyy") : "",
                    FECFIN = item.FECFIN.HasValue ? item.FECFIN.Value.ToString("dd/MM/yyyy") : ""
                });
            }
            return listadoFinal;
        }

    }
}