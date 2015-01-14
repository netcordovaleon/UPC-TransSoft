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
    public interface IReservaLogic
    {
        ResponseEntity RegistrarReserva(List<SRV_PASAJERO> listPasajero, SRV_RESERVA reserva);
        ResponseEntity AnularReserva(int codReserva);
    }
}
