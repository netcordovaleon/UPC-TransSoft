using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
namespace UPC.TS.Web.Models
{
    public class ReservaModels
    {
        public FiltrosReservaModels filtros { get; set; }
        public IEnumerable<ProgramacionDataModels> listaProgramacion { get; set; }
        public ReservaModels()
        {
            this.filtros = new FiltrosReservaModels();
            this.listaProgramacion = new List<ProgramacionDataModels>();
        }

        #region CONVETIR LISTAS
        public List<ProgramacionDataModels> castProgramacionType(List<VWCONSULTAPROGRAMACION> lista)
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
        #endregion
    }


    #region LISTADO BUSQUEDA PROGRAMACION

    public class ProgramacionDataModels {
        public int CODPRO { get; set; }
        public string FECSALPRO { get; set; }
        public string HORSALPRO { get; set; }
        public string ORITAR { get; set; }
        public string DESTAR { get; set; }
        public Nullable<decimal> PRETAR { get; set; }
        public string NOMTIPSER { get; set; }
        public Nullable<int> CUPASI { get; set; }
    }

    #endregion

}