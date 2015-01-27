using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UPC.TS.Web.Models
{
    public class UsuarioModels
    {
        public int CODUSU { get; set; }
        [Display(Name = "Ingrese contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CLAUSU { get; set; }
        [Display(Name = "Repita contraseña")]
        [Compare("CLAUSU", ErrorMessage = "Las contraseñas deben coincidir")]
        public string CLAUSU_REP { get; set; }
        public string ESTREG { get; set; }
        [Display(Name="Ingrese correo electronico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string LOGUSU { get; set; }
    }
}