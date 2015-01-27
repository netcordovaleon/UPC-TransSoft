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
    public interface IPromocionLogic
    {
        ResponseEntity GrabarPromocion(SRV_PROMOCION entidad);
        ResponseEntity EliminarPromocion(int id);
        SRV_PROMOCION BuscarPorId(int id);
        IEnumerable<SRV_PROMOCION> ListarPromocion();
        IEnumerable<SRV_PROMOCION> ListarPromocionFiltro(SRV_PROMOCION entidad);
        
    }
}
