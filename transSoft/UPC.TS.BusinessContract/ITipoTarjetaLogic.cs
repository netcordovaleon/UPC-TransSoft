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
    public interface ITipoTarjetaLogic
    {
        SRV_TIPO_TARJETA BuscarPorId(int id);
        ResponseEntity RegistrarTipoTarjeta(SRV_TIPO_TARJETA entidad);
        ResponseEntity ActualizarTipoTarjeta(SRV_TIPO_TARJETA entidad);
        ResponseEntity EliminarTipoTarjeta(int id);
        IEnumerable<SRV_TIPO_TARJETA> ListarTodo();
        IEnumerable<SRV_TIPO_TARJETA> ListarTiposTarjeta(SRV_TIPO_TARJETA entidad);
    }
}
