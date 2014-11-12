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
    public class TarifasData : BaseRepository<TARIFA>, ITarifas
    {
        public TarifasData(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<TARIFA> ListarOrigen()
        {
            var tarifas = this.GetAll();
            var origen = (from c in tarifas select new TARIFA { ORITAR = c.ORITAR }).Distinct();
            return origen;
        }

        public IEnumerable<TARIFA> ListarDestino()
        {
            var tarifas = this.GetAll();
            var destino = (from c in tarifas select new TARIFA { DESTAR = c.DESTAR }).Distinct();
            return destino;
        }

        public TARIFA Registrar(TARIFA entidad)
        {
            throw new NotImplementedException();
        }

        public TARIFA Actualizar(TARIFA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public TARIFA BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TARIFA> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
