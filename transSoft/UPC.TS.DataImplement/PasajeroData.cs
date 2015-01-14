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
    public class PasajeroData : BaseRepository<SRV_PASAJERO>, IPasajero
    {
        public PasajeroData(IUnitOfWork unit) : base(unit) { }

        public SRV_PASAJERO Registrar(SRV_PASAJERO entidad)
        {
            return (SRV_PASAJERO)this.Insert(entidad);
        }

        public SRV_PASAJERO Actualizar(SRV_PASAJERO entidad)
        {
            return (SRV_PASAJERO)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SRV_PASAJERO BuscarPorId(int id)
        {
            return this.Get(c => c.CODPAS == id);
        }

        public IEnumerable<SRV_PASAJERO> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SRV_PASAJERO> ListarPasajeroPorReserva(int CODRES)
        {
            return this.GetMany(c => c.CODRES == CODRES);
        }
    }
}
