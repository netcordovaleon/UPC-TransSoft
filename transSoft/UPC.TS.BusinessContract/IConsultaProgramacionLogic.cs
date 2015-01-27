using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.Infraestructure;
using UPC.TS.Infraestructure.Entidades;

namespace UPC.TS.BusinessContract
{
    public interface IConsultaProgramacionLogic
    {
        SRV_VW_CONSULTA_PROGRAMACION BuscarPorId(int id);
        IEnumerable<SRV_VW_CONSULTA_PROGRAMACION> ListarProgramacion(string origen, string destino, string fechaSalida);
    }
}
