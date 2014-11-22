using System;
using System.Transactions;
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
    public class ReservaLogic : IReservaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IReserva _reservaData;
        private readonly IPasajero _pasajeroData;
        public ReservaLogic()
        {
            this._uow = new UnitOfWork();
            this._reservaData = new ReservaData(_uow);
            this._pasajeroData = new PasajeroData(_uow);
        }


        public ResponseEntity RegistrarReserva(List<PASAJERO> listPasajero, RESERVA reserva)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try {
                    var entidadReserva = _reservaData.Registrar(reserva);
                    foreach (var item in listPasajero) {
                        item.CODRES = entidadReserva.CODRES;
                        _pasajeroData.Registrar(item);
                    }                        
                    tran.Complete();
                    return new ResponseEntity("Se registro su reserva satisfactoriamente", true);
                } catch (Exception) {
                    tran.Dispose();
                    return new ResponseEntity(Response.ErrorGeneral);
                }
            }
        }
    }
}
