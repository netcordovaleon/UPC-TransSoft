using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;

namespace UPC.TS.Web.Models
{
    public class TipoTarjetaModel
    {
        public TipoTarjetaModels TipoTarjeta { get; set; }
        public List<TipoTarjetaModels> LIST_TARJETA { get; set; }
        public TipoTarjetaModel()
        {
            this.LIST_TARJETA = new List<TipoTarjetaModels>();
            this.TipoTarjeta = new TipoTarjetaModels();
        }
    }

    public class TipoTarjetaModels
    {
        public int CODTIPTAR { get; set; }
        [Display(Name="Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NOMTIPTAR { get; set; }
        [Display(Name="Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string ESTREG { get; set; }
        [Display(Name="Tipo de Pago")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string MEDPAG { get; set; }
        public string MEDPAGDES { get; set; }
        
        public IEnumerable<SelectListItem> LIST_MEDPAGO { get; set; }
        public IEnumerable<SelectListItem> LIST_ESTREG { get; set; }
        public TipoTarjetaModels()
        {
            var medios = new List<SelectListItem>();
            medios.Add(new SelectListItem() { Text = "Débito", Value = "D" });
            medios.Add(new SelectListItem() { Text = "Crédito", Value = "C" });

            var estados = new List<SelectListItem>();
            estados.Add(new SelectListItem() { Text = "Activo", Value = "1" });
            estados.Add(new SelectListItem() { Text = "Inactivo", Value = "0" });

            this.LIST_MEDPAGO = medios;
            this.LIST_ESTREG = estados;
        }

        public List<TipoTarjetaModels> castTipoTarjetaType(List<SRV_TIPO_TARJETA> lista)
        {
            var listadoFinal = new List<TipoTarjetaModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new TipoTarjetaModels()
                {
                    CODTIPTAR = item.CODTIPTAR,
                    NOMTIPTAR = item.NOMTIPTAR,
                    ESTREG = item.ESTREG,
                    MEDPAG = item.MEDPAG,
                    MEDPAGDES = item.MEDPAG.Equals("D") ? "Débito" : "Crédito"
                });
            }
            return listadoFinal;
        }
    }
}