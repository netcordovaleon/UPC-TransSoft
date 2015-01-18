using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Infraestructure;
using UPC.TS.Infraestructure.Enum;

namespace UPC.TS.DataImplement
{
    public class ConsultaReservaData : BaseRepository<SRV_VW_RESERVAS>, IConsultaReserva
    {
        public ConsultaReservaData(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuario(string CORCLI)
        {
            return this.GetMany(c => c.CORCLI.Equals(CORCLI) && c.ESTTRAN == EstadoTranReserva.RESERVADO);
        }


        public IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuarioyReserva(int CODRES, string CORCLI)
        {
            return this.GetMany(c => c.CORCLI.Equals(CORCLI) && c.CODRES == CODRES && c.ESTTRAN == EstadoTranReserva.RESERVADO);
        }
    }
}
