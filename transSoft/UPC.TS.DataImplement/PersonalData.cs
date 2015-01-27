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
    public class PersonalData : BaseRepository<SRV_PERSONAL>, IPersonal, IDisposable
    {
        public PersonalData(IUnitOfWork unit) : base(unit) { }

        public SRV_PERSONAL Registrar(SRV_PERSONAL entidad)
        {
            return (SRV_PERSONAL)this.Insert(entidad);
        }

        public SRV_PERSONAL Actualizar(SRV_PERSONAL entidad)
        {
            return (SRV_PERSONAL)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_PERSONAL BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_PERSONAL> ListarTodo()
        {
            return this.GetMany(c => c.ESTREG == "1");
        }

        public bool ExistePersonal(SRV_PERSONAL entidad)
        {
            var existe = this.Get(c => c.DNIPER == entidad.DNIPER);
            if (existe == null)
                return false;
            else
                return true;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
