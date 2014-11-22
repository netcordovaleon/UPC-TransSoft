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
    public class PasajeroData : BaseRepository<PASAJERO>, IPasajero
    {
        public PasajeroData(IUnitOfWork unit) : base(unit) { }

        public PASAJERO Registrar(PASAJERO entidad)
        {
            return (PASAJERO)this.Insert(entidad);
        }

        public PASAJERO Actualizar(PASAJERO entidad)
        {
            return (PASAJERO)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public PASAJERO BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PASAJERO> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
