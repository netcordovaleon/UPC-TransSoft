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
    public class PasajeroLogic : IPasajeroLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly IPasajero _pasajeroData;
        public PasajeroLogic()
        {
            this._uow = new UnitOfWork();
            this._pasajeroData = new PasajeroData(_uow);
        }

        public ResponseEntity GrabarPasajeros(SRV_PASAJERO entidad)
        {
            if (entidad.CODPAS.Equals(0))
            {
                _pasajeroData.Registrar(entidad);
            }
            else {
                _pasajeroData.Actualizar(entidad);
            }
            return new ResponseEntity("Se grabaron los datos del pasajero satisfactoriamente", true);
        }

        public ResponseEntity RegistrarPasajeros(List<SRV_PASAJERO> listPasajero)
        {
            using (TransactionScope tran = new TransactionScope()) {
                try
                {
                    foreach (var item in listPasajero)
	                {
                        _pasajeroData.Registrar(item);
	                }
                    tran.Complete();
                    return new ResponseEntity("Se registro sus pasajeros satisfactoriamente", true);
                }
                catch (Exception)
                {
                    tran.Dispose();
                    return new ResponseEntity(Response.ErrorGeneral);
                }
            }
        }


        public IEnumerable<SRV_PASAJERO> ListarPasajeroPorReserva(int codReserva)
        {
            return _pasajeroData.ListarPasajeroPorReserva(codReserva);
        }


        public SRV_PASAJERO BuscarPorId(int id)
        {
            return _pasajeroData.BuscarPorId(id);
        }
    }
}
