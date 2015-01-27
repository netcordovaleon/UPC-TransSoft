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
    public class TarjetaData : BaseRepository<SRV_TARJETA>, ITarjeta
    {
        public TarjetaData(IUnitOfWork unit) : base(unit) { }

        public SRV_TARJETA Registrar(SRV_TARJETA entidad)
        {
            return (SRV_TARJETA)this.Insert(entidad);
        }

        public SRV_TARJETA Actualizar(SRV_TARJETA entidad)
        {
            return (SRV_TARJETA)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_TARJETA BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_TARJETA> ListarTodo()
        {
            return this.GetMany(c => c.ESTREG == "1");
        }

    }
}
