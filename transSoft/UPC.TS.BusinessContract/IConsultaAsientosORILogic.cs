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
    public interface IConsultaAsientosORILogic
    {
        IEnumerable<SRV_VW_ASIENTOS_RESERVADOSORI> ListarAsientosORI(int codProgramacion);
    }
}
