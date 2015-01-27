using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.Infraestructure.Contratos;
using UPC.TS.Entities;

namespace UPC.TS.DataContract
{
    public interface IConsultaProgramacion
    {
        SRV_VW_CONSULTA_PROGRAMACION BuscarPorId(int id);
        IEnumerable<SRV_VW_CONSULTA_PROGRAMACION> ListarProgramacion(string ORITAR, string DESTAR, string FECSALPRO);
    }
}
