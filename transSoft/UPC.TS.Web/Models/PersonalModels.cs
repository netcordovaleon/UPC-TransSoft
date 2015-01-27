using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;

namespace UPC.TS.Web.Models
{
    public class PersonalModel
    {
        public PersonalModels Personal { get; set; }
        public List<PersonalModels> LIST_PERSONAL { get; set; }
        public PersonalModel()
        {
            this.LIST_PERSONAL = new List<PersonalModels>();
            this.Personal = new PersonalModels();
        }
    }

    public class PersonalModels
    {
        public int CODPER { get; set; }
        [Display(Name="Nombre Personal")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NOMPER { get; set; }
        [Display(Name="Apellidos Personal")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string APEPER { get; set; }
        [Display(Name="Nro. DNI")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DNIPER { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODUSU { get; set; }
        public UsuarioModels Usuario { get; set; }
        public List<PersonalModels> castPersonalType(List<SRV_PERSONAL> lista)
        {
            var listadoFinal = new List<PersonalModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new PersonalModels()
                {
                    CODPER = item.CODPER,
                    NOMPER = item.NOMPER,
                    APEPER = item.APEPER,
                    DNIPER = item.DNIPER,
                    ESTREG = item.ESTREG,
                    CODUSU = item.CODUSU
                });
            }
            return listadoFinal;
        }

        public List<PersonalModels> castPersonalType(List<SRV_VW_CONSULTA_PERSONAL> lista)
        {
            var listadoFinal = new List<PersonalModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new PersonalModels()
                {
                    CODPER = item.CODPER,
                    NOMPER = item.NOMPER,
                    APEPER = item.APEPER,
                    DNIPER = item.DNIPER,
                    CODUSU = item.CODUSU,
                    Usuario = new UsuarioModels() { LOGUSU = item.LOGUSU }
                });
            }
            return listadoFinal;
        }

        public PersonalModels()
        {
            Usuario = new UsuarioModels();
        }
    }
}