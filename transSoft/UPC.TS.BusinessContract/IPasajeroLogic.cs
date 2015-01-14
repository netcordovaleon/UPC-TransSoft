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
    public interface IPasajeroLogic
    {
        ResponseEntity GrabarPasajeros(SRV_PASAJERO entidad);
        ResponseEntity RegistrarPasajeros(List<SRV_PASAJERO> listPasajero);
        IEnumerable<SRV_PASAJERO> ListarPasajeroPorReserva(int codReserva);
        SRV_PASAJERO BuscarPorId(int id);
    }
}
