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
    public interface IConsultaReservaLogic
    {
        IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuario(string correoCliente);
        IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuarioyReserva(int codReserva, string correoCliente);
    }
}
