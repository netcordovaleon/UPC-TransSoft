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
    public class TipoTarjetaData : BaseRepository<SRV_TIPO_TARJETA>, ITipoTarjeta, IDisposable
    {
        public TipoTarjetaData(IUnitOfWork unit) : base(unit) { }

        public SRV_TIPO_TARJETA Registrar(SRV_TIPO_TARJETA entidad)
        {
            return (SRV_TIPO_TARJETA)this.Insert(entidad);
        }

        public SRV_TIPO_TARJETA Actualizar(SRV_TIPO_TARJETA entidad)
        {
            return (SRV_TIPO_TARJETA)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_TIPO_TARJETA BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_TIPO_TARJETA> ListarTodo()
        {
            return this.GetMany(c => c.ESTREG == "1");
        }

        public IEnumerable<SRV_TIPO_TARJETA> ListarTiposTarjeta(SRV_TIPO_TARJETA entidad)
        {
            if (!string.IsNullOrEmpty(entidad.MEDPAG) && !string.IsNullOrEmpty(entidad.NOMTIPTAR) && !string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.MEDPAG.Equals(entidad.MEDPAG) && c.NOMTIPTAR.Contains(entidad.NOMTIPTAR) && c.ESTREG.Equals(entidad.ESTREG));

            if (string.IsNullOrEmpty(entidad.MEDPAG) && !string.IsNullOrEmpty(entidad.NOMTIPTAR) && !string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c=> c.NOMTIPTAR.Contains(entidad.NOMTIPTAR) && c.ESTREG.Equals(entidad.ESTREG));

            if (!string.IsNullOrEmpty(entidad.MEDPAG) && string.IsNullOrEmpty(entidad.NOMTIPTAR) && !string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.MEDPAG.Equals(entidad.MEDPAG) && c.ESTREG.Equals(entidad.ESTREG));

            if (!string.IsNullOrEmpty(entidad.MEDPAG) && !string.IsNullOrEmpty(entidad.NOMTIPTAR) && string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.MEDPAG.Equals(entidad.MEDPAG) && c.NOMTIPTAR.Contains(entidad.NOMTIPTAR));

            if (!string.IsNullOrEmpty(entidad.MEDPAG) && string.IsNullOrEmpty(entidad.NOMTIPTAR) && string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.MEDPAG.Equals(entidad.MEDPAG));

            if (string.IsNullOrEmpty(entidad.MEDPAG) && !string.IsNullOrEmpty(entidad.NOMTIPTAR) && string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.NOMTIPTAR.Contains(entidad.NOMTIPTAR));

            if (string.IsNullOrEmpty(entidad.MEDPAG) && string.IsNullOrEmpty(entidad.NOMTIPTAR) && !string.IsNullOrEmpty(entidad.ESTREG))
                return this.GetMany(c => c.ESTREG.Equals(entidad.ESTREG));

            return this.GetMany();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
