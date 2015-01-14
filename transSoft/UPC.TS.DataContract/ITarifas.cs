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
    public interface ITarifas  : IOperacionesCRUD<SRV_TARIFA> 
    {
        IEnumerable<SRV_TARIFA> ListarOrigen();
        IEnumerable<SRV_TARIFA> ListarDestino();
        IEnumerable<SRV_TARIFA> ListarTarifaFiltro(SRV_TARIFA entidad);
    }
}
