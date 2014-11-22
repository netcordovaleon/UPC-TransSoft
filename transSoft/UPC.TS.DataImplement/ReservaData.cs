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
    public class ReservaData : BaseRepository<RESERVA>, IReserva
    {

        public ReservaData(IUnitOfWork unit) : base(unit) { }

        public RESERVA Registrar(RESERVA entidad)
        {
            return (RESERVA)this.Insert(entidad);
        }

        public RESERVA Actualizar(RESERVA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public RESERVA BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RESERVA> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
