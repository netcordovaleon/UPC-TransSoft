using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UPC.TS.Web.Models
{
    public class PasajeroModels
    {
        public int CODPAS { get; set; }
        [Display(Name = "Nombres")]
        public string NOMPAS { get; set; }
        [Display(Name = "Apellido paterno")]
        public string APEPPAS { get; set; }
        [Display(Name = "Apellido materno")]
        public string APEMPAS { get; set; }
        [Display(Name = "Direccion")]
        public string DIRPAS { get; set; }
        [Display(Name = "Sexo")]
        public string SEXPAS { get; set; }
        [Display(Name = "Celular")]
        public string CELPAS { get; set; }
        [Display(Name = "Telefono")]
        public string TELPAS { get; set; }
        public string ESTREG { get; set; }
        public string ESTTRAN { get; set; }
        public Nullable<int> CODRES { get; set; }
        [Display(Name="Tipo de documento")]
        public string TIPDOC { get; set; }
        [Display(Name = "Nº documento")]
        public string NUMDOC { get; set; }

        public string NUMASI_ORI { get; set; }
        public string NUMASI_DES { get; set; }

        public string TIPVIA { get; set; }
    }
}