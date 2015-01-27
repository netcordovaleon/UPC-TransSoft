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
    public class PromocionData : BaseRepository<SRV_PROMOCION>, IPromocion
    {
        public PromocionData(IUnitOfWork unit) : base(unit) { }

        public SRV_PROMOCION Registrar(SRV_PROMOCION entidad)
        {
            return (SRV_PROMOCION)this.Insert(entidad);
        }

        public SRV_PROMOCION Actualizar(SRV_PROMOCION entidad)
        {
            return (SRV_PROMOCION)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_PROMOCION BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_PROMOCION> ListarTodo()
        {
            return this.GetMany(c => c.ESTREG == "1");
        }

        public IEnumerable<SRV_PROMOCION> ListarPromocionFiltro(SRV_PROMOCION entidad)
        {
            var lista = new List<SRV_PROMOCION>();
            lista = this.GetMany(c => c.ESTREG == "1").ToList();
            if (!string.IsNullOrEmpty(entidad.DESPROM))
            {
                lista = lista.Where(c => c.DESPROM.ToLower().Contains(entidad.DESPROM.ToLower())).ToList();
            }
            if (entidad.FECINI.HasValue)
            {
                lista = lista.Where(c => c.FECINI >= entidad.FECINI).ToList();
            }
            if (entidad.FECFIN.HasValue)
            {
                lista = lista.Where(c => c.FECFIN <= entidad.FECFIN).ToList();
            }
            return lista;
        }
    }
}
