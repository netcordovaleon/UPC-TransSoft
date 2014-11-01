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
    public class ContactenosData : BaseRepository<contactenos>, IContactenos
    {

        public ContactenosData(IUnitOfWork unit) : base(unit) { }

        public bool grabarContactenos(contactenos entity)
        {
            try {   
                this.Insert(entity);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public contactenos Registrar(contactenos entidad)
        {
            var entity = this.Insert(entidad);
            return (contactenos)entity;
        }

        public contactenos Actualizar(contactenos entidad)
        {
            var entity = this.Update(entidad);
            return (contactenos)entity;
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public contactenos BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<contactenos> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
