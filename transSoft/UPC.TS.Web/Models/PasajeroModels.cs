using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Infraestructure.Entidades;
namespace UPC.TS.Web.Models
{
    public class PasajeroModels
    {
        public int CODPAS { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NOMPAS { get; set; }
        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string APEPPAS { get; set; }
        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string APEMPAS { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DIRPAS { get; set; }
        [Display(Name = "Sexo")]
        public string SEXPAS { get; set; }
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CELPAS { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TELPAS { get; set; }
        public string ESTREG { get; set; }
        public string ESTTRAN { get; set; }
        public Nullable<int> CODRES { get; set; }
        [Display(Name="Tipo de documento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TIPDOC { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Nº documento")]
        public string NUMDOC { get; set; }
        public string NUMASI_ORI { get; set; }
        public string NUMASI_DES { get; set; }
        public string TIPVIA { get; set; }

        public string NUMASI { get; set; }

        public List<SelectListItem> LIST_SEXO { get; set; }
        public List<SelectListItem> LIST_TIPDOC { get; set; }

        public PasajeroModels() {

            this.LIST_SEXO = new List<SelectListItem>();
            this.LIST_TIPDOC = new List<SelectListItem>();

            LIST_SEXO.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
            LIST_SEXO.Add(new SelectListItem() { Text = "Femenino", Value = "F" });

            LIST_TIPDOC.Add(new SelectListItem() { Text = "DNI", Value = "1" });
            LIST_TIPDOC.Add(new SelectListItem() { Text = "Carnet extranjeria", Value = "2" });

        }
    }
}