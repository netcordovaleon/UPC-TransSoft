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
    public class ClienteData : BaseRepository<CLIENTE>, ICliente
    {

        public ClienteData(IUnitOfWork unit) : base(unit) { }

        public CLIENTE Registrar(CLIENTE entidad)
        {
            return (CLIENTE)this.Insert(entidad);
        }

        public CLIENTE Actualizar(CLIENTE entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public CLIENTE BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CLIENTE> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public CLIENTE ObtenerUsuarioPorCorreo(string correo)
        {
            return this.Get(c => c.CORCLI == correo);
        }
    }
}
