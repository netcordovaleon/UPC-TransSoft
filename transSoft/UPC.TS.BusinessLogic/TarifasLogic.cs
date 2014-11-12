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
    public class TarifasLogic : ITarifasLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ITarifas _tarifasData;
        public TarifasLogic()
        {
            this._uow = new UnitOfWork();
            this._tarifasData = new TarifasData(_uow);
        }
        public IEnumerable<TARIFA> ListarOrigen()
        {
            return _tarifasData.ListarOrigen();
        }

        public IEnumerable<TARIFA> ListarDestino()
        {
            return _tarifasData.ListarDestino();
        }
    }
}
