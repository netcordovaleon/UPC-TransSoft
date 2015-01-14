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
    public interface ITarifasLogic
    {
        ResponseEntity GrabarTarifa(SRV_TARIFA entidad);
        ResponseEntity EliminarTarifa(int id);
        SRV_TARIFA BuscarPorId(int id);
        IEnumerable<SRV_TARIFA> ListarTarifas();       
        IEnumerable<SRV_TARIFA> ListarOrigen();
        IEnumerable<SRV_TARIFA> ListarDestino();
        IEnumerable<SRV_TARIFA> ListarTarifaFiltro(SRV_TARIFA entidad);
    }
}
