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

namespace UPC.TS.DataImplement
{
    public class ReservaData : BaseRepository<SRV_RESERVA>, IReserva
    {

        public ReservaData(IUnitOfWork unit) : base(unit) { }

        public SRV_RESERVA Registrar(SRV_RESERVA entidad)
        {
            return (SRV_RESERVA)this.Insert(entidad);
        }

        public SRV_RESERVA Actualizar(SRV_RESERVA entidad)
        {
            return (SRV_RESERVA)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SRV_RESERVA BuscarPorId(int id)
        {
            return (SRV_RESERVA)this.Get(c => c.CODRES == id);
        }

        public IEnumerable<SRV_RESERVA> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
