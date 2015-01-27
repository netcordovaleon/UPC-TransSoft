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
    public class CompraData : BaseRepository<SRV_COMPRA>, ICompra
    {
        public CompraData(IUnitOfWork unit) : base(unit) { }

        public SRV_COMPRA Registrar(SRV_COMPRA entidad)
        {
            return (SRV_COMPRA)this.Insert(entidad);
        }

        public SRV_COMPRA Actualizar(SRV_COMPRA entidad)
        {
            return (SRV_COMPRA)this.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            this.Delete(id);
            return true;
        }

        public SRV_COMPRA BuscarPorId(int id)
        {
            return this.Single(id);
        }

        public IEnumerable<SRV_COMPRA> ListarTodo()
        {
            return this.GetMany();
        }

        public IEnumerable<SRV_COMPRA> ListarVentas(DateTime fechaIni, DateTime fechaFin)
        {
            return this.GetMany(c => c.FECCOM.Value >= fechaIni && c.FECCOM.Value <= fechaFin && c.ESTREG == "1");
        }
    }
}
