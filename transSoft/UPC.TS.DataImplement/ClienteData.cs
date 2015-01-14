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
    public class ClienteData : BaseRepository<SRV_CLIENTE>, ICliente
    {

        public ClienteData(IUnitOfWork unit) : base(unit) { }

        public SRV_CLIENTE Registrar(SRV_CLIENTE entidad)
        {
            return (SRV_CLIENTE)this.Insert(entidad);
        }

        public SRV_CLIENTE Actualizar(SRV_CLIENTE entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SRV_CLIENTE BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SRV_CLIENTE> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public SRV_CLIENTE ObtenerUsuarioPorCorreo(string correo)
        {
            return this.Get(c => c.CORCLI == correo);
        }
    }
}
