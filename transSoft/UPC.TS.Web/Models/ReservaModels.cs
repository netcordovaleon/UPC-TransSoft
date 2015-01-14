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
        public int CODPRO_ORI { get; set; }
        public int CODPRO_DES { get; set; }
        public FiltrosReservaModels filtros { get; set; }
        public PasajeroModels pasajero { get; set; }
        public IEnumerable<ProgramacionDataModels> listaProgramacion { get; set; }
        public IEnumerable<ProgramacionDataModels> listaProgramacionDestino { get; set; }
        public IEnumerable<ReservaVistaModels> listaReservasVista { get; set; }
        public IEnumerable<PasajeroModels> listaPasajeros { get; set; }
        public ReservaModels()
        {
            this.filtros = new FiltrosReservaModels();
            this.pasajero = new PasajeroModels();
            this.listaProgramacion = new List<ProgramacionDataModels>();
            this.listaReservasVista = new List<ReservaVistaModels>();
            this.listaPasajeros = new List<PasajeroModels>();
        }

        #region CONVETIR LISTAS
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

        public List<ReservaVistaModels> castReservaVistaType(List<SRV_VW_RESERVAS> lista)
        {
            var listadoFinal = new List<ReservaVistaModels>();
            foreach (var item in lista)
            {
                listadoFinal.Add(new ReservaVistaModels()
                {
                     CODRES = item.CODRES,
                     FECRES = item.FECRES,
                     FECSALPRO = item.FECSALPRO,
                     HORSALPRO = item.HORSALPRO,
                     ORITAR = item.ORITAR,
                     DESTAR = item.DESTAR,
                     TIPVIA = item.TIPVIA
                });
            }
            return listadoFinal;
        }

        public List<PasajeroModels> castPasajerosType(List<SRV_PASAJERO> lista) {
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