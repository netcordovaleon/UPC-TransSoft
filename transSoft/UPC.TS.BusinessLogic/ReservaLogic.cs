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
using UPC.TS.Infraestructure.Enum;

namespace UPC.TS.BusinessLogic
{
    public class ReservaLogic : IReservaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IReserva _reservaData;
        private readonly IPasajero _pasajeroData;
        private readonly ICompra _compraData;
        private readonly ITarjeta _tarjetaData;
        public ReservaLogic()
        {
            this._uow = new UnitOfWork();
            this._reservaData = new ReservaData(_uow);
            this._pasajeroData = new PasajeroData(_uow);
            this._compraData = new CompraData(_uow);
            this._tarjetaData = new TarjetaData(_uow);
        }

        public SRV_RESERVA BuscarPorId(int id)
        {
            return this._reservaData.BuscarPorId(id);
        }

        public ResponseEntity RegistrarReserva(List<SRV_PASAJERO> listPasajero, SRV_RESERVA reserva)
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
                    return new ResponseEntity(string.Format("Se registro su reserva satisfactoriamente, Su numero de Reserva es : {0}",  Infraestructure.Funciones.StringAdding.Right("000000" + entidadReserva.CODRES.ToString(), 5)) , true);
                } catch (Exception) {
                    tran.Dispose();
                    return new ResponseEntity(Response.ErrorGeneral);
                }
            }
        }


        public ResponseEntity AnularReserva(int codReserva)
        {
            try
            {
                var reserva = _reservaData.BuscarPorId(codReserva);
                reserva.ESTTRAN = EstadoTranReserva.ANULADO;
                _reservaData.Actualizar(reserva);
                return new ResponseEntity("Anulo la reserva seleccionada satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity PagarReserva(int codReserva, SRV_TARJETA tarjeta, SRV_COMPRA compra)
        {
            try
            {
                using(var scope = new TransactionScope())
                {
                    var reserva = _reservaData.BuscarPorId(codReserva);

                    if(reserva.ESTTRAN != EstadoTranReserva.RESERVADO)
                        return new ResponseEntity("La reserva no se encuentra en estado RESERVADO");

                    var tarjetaReg = this._tarjetaData.Registrar(tarjeta);

                    compra.CODTARJETA = tarjetaReg.CODTARJETA;
                    compra.CODCON = DateTime.Now.ToString("mmyy") + "PE" + reserva.CODRES.ToString("000");

                    var compraReg = this._compraData.Registrar(compra);

                    reserva.ESTTRAN = EstadoTranReserva.PAGADO;
                    _reservaData.Actualizar(reserva);

                    scope.Complete();
                }
                
                return new ResponseEntity("Se realizo el pago satisfactoriamente", true, compra.CODCON);
            }
            catch (Exception)
            {

                return new ResponseEntity(Response.ErrorGeneral);
            }
        }
    }
}
