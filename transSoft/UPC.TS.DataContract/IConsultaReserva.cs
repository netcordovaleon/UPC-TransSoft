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
    public interface IConsultaReserva
    {
        IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuario(string CORCLI);
        IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuarioyReserva(int CODRES, string CORCLI);
    }
}
