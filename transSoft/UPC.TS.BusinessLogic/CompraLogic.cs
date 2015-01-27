using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.BusinessContract;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Entities;
using UPC.TS.Infraestructure.Entidades;
using UPC.TS.Infraestructure.Mensajes.Respuesta;

namespace UPC.TS.BusinessLogic
{
    public class CompraLogic : ICompraLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ICompra _compraData;
        public CompraLogic()
        {
            this._uow = new UnitOfWork();
            this._compraData = new CompraData(_uow);

        }
        public IEnumerable<SRV_COMPRA> ListarVentas(DateTime fechaIni, DateTime fechaFin)
        {
            return this._compraData.ListarVentas(fechaIni, fechaFin);
        }
    }
}
