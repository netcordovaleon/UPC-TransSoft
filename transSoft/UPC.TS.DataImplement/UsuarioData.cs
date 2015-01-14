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
    public class UsuarioData : BaseRepository<SRV_USUARIO>, IUsuario, IDisposable
    {
        public UsuarioData(IUnitOfWork unit) : base(unit) { }
        public bool IngresarSistema(SRV_USUARIO entidad)
        {
            var existe = this.Get(c => c.LOGUSU == entidad.LOGUSU && c.CLAUSU == entidad.CLAUSU);
            if (existe == null)
                return false;
            else
                return true;
        }

        public bool ExisteUsuarioReg(SRV_USUARIO entidad)
        {
            var existe = this.Get(c => c.LOGUSU == entidad.LOGUSU);
            if (existe == null)
                return false;
            else
                return true;
        }

        public SRV_USUARIO Registrar(SRV_USUARIO entidad)
        {
            return (SRV_USUARIO)this.Insert(entidad);
        }

        public SRV_USUARIO Actualizar(SRV_USUARIO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SRV_USUARIO BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SRV_USUARIO> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
