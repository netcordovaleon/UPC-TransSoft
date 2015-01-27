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
        SRV_RESERVA BuscarPorId(int id);
        ResponseEntity RegistrarReserva(List<SRV_PASAJERO> listPasajero, SRV_RESERVA reserva);
        ResponseEntity AnularReserva(int codReserva);
        ResponseEntity PagarReserva(int codReserva, SRV_TARJETA tarjeta, SRV_COMPRA compra);
    }
}
