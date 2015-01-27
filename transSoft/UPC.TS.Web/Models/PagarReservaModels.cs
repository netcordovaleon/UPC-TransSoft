using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UPC.TS.Entities;
using System.Web.Mvc;

namespace UPC.TS.Web.Models
{

    public class PagarReservaModels
    {
        [Display(Name = "Código Reserva")]
        public int CODRES { get; set; }
        [Display(Name = "Fecha Reserva")]
        public string FECRES { get; set; }

        public TarjetaModels Tarjeta { get; set; }
        public CompraModels Compra { get; set; }

        public IEnumerable<ProgramacionDataModels> listaProgramacion { get; set; }
        public IEnumerable<PasajeroModels> listaPasajeros { get; set; }

        public PagarReservaModels()
        {
            this.listaProgramacion = new List<ProgramacionDataModels>();
            this.listaPasajeros = new List<PasajeroModels>();
            this.Tarjeta = new TarjetaModels();
            this.Compra = new CompraModels();
        }

        public List<ProgramacionDataModels> castProgramacionType(List<SRV_VW_CONSULTA_PROGRAMACION> lista)
        {
            var listadoFinal = new List<ProgramacionDataModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new ProgramacionDataModels()
                {
                    CODPRO = item.CODPRO,
                    CUPASI = item.CUPASI,
                    DESTAR = item.DESTAR,
                    ORITAR = item.ORITAR,
                    FECSALPRO = item.FECSALPRO,
                    HORSALPRO = item.HORSALPRO,
                    NOMTIPSER = item.NOMTIPSER,
                    PRETAR = item.PRETAR
                });
            }
            return listadoFinal;
        }

        public List<PasajeroModels> castPasajerosType(IEnumerable<SRV_PASAJERO> lista)
        {
            var listadoFinal = new List<PasajeroModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new PasajeroModels()
                {
                    CODPAS = item.CODPAS,
                    CODRES = item.CODRES,
                    NOMPAS = item.NOMPAS,
                    APEPPAS = item.APEPPAS,
                    APEMPAS = item.APEMPAS,
                    TELPAS = item.TELPAS,
                    CELPAS = item.CELPAS,
                    DIRPAS = item.DIRPAS,
                    SEXPAS = item.SEXPAS,
                    TIPVIA = item.TIPVIA,
                    TIPDOC = item.TIPDOC,
                    NUMDOC = item.NUMDOC,
                    NUMASI_ORI = item.NUMASI
                });
            }
            return listadoFinal;
        }
    }

    public class CompraModels
    {
        public int CODCOM { get; set; }
        public string CODCON { get; set; }
        public Nullable<System.DateTime> FECCOM { get; set; }
        [Display(Name = "Sub Total S/.:")]
        public Nullable<decimal> SUBTOT { get; set; }
        [Display(Name = "I.G.V. - 18% S/.:")]
        public Nullable<decimal> VALIGV { get; set; }
        [Display(Name = "Total a Pagar S/.:")]
        public Nullable<decimal> MONTOT { get; set; }
        public Nullable<int> CODRES { get; set; }
        public Nullable<int> CODTARJETA { get; set; }        
    }

    public class TarjetaModels
    {
        public int CODTARJETA { get; set; }
        [Display(Name="Número de Tarjeta")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NUMTAR { get; set; }
        [Display(Name = "Código Verificación")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CODVER { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NOMTIT { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string APETIT { get; set; }
        [Display(Name = "Fecha de Vencimiento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FECEXP { get; set; }
        public string ESTREG { get; set; }
        [Display(Name = "Medio Pago")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<int> CODTIPTAR { get; set; }

        public IEnumerable<SelectListItem> LIST_TIPTAR { get; set; }

        public TarjetaModels()
        {
            this.LIST_TIPTAR = new List<SelectListItem>();
        }

        public List<SelectListItem> castTipoTarjetaType(List<SRV_TIPO_TARJETA> lista)
        {
            var listadoFinal = new List<SelectListItem>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new SelectListItem()
                {
                    Value = item.CODTIPTAR.ToString(),
                    Text = string.Format("{0} - {1}", (item.MEDPAG.Equals("D") ? "Débito" : "Crédito"), item.NOMTIPTAR)
                });
            }
            return listadoFinal;
        }

    }
}