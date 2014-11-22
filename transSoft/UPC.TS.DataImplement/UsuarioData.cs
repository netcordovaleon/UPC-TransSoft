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
    public class UsuarioData : BaseRepository<USUARIO>, IUsuario, IDisposable
    {
        public UsuarioData(IUnitOfWork unit) : base(unit) { }
        public bool IngresarSistema(USUARIO entidad)
        {
            var existe = this.Get(c => c.LOGUSU == entidad.LOGUSU && c.CLAUSU == entidad.CLAUSU);
            if (existe == null)
                return false;
            else
                return true;
        }

        public bool ExisteUsuarioReg(USUARIO entidad)
        {
            var existe = this.Get(c => c.LOGUSU == entidad.LOGUSU);
            if (existe == null)
                return false;
            else
                return true;
        }

        public USUARIO Registrar(USUARIO entidad)
        {
            return (USUARIO)this.Insert(entidad);
        }

        public USUARIO Actualizar(USUARIO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public USUARIO BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<USUARIO> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
