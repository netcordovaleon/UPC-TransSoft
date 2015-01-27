using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UPC.TS.BusinessContract;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Entities;
using UPC.TS.Infraestructure.Entidades;
using UPC.TS.Infraestructure.Enum;
using UPC.TS.Infraestructure.Mensajes.Respuesta;

namespace UPC.TS.BusinessLogic
{
    public class TipoTarjetaLogic : ITipoTarjetaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ITipoTarjeta _tipoTarjetaData;

        public TipoTarjetaLogic()
        {
            this._uow = new UnitOfWork();
            this._tipoTarjetaData = new TipoTarjetaData(_uow);

        }
        public SRV_TIPO_TARJETA BuscarPorId(int id)
        {
            return this._tipoTarjetaData.BuscarPorId(id);
        }

        public ResponseEntity RegistrarTipoTarjeta(SRV_TIPO_TARJETA entidad)
        {
            try
            {
                var tarjetaReg = this._tipoTarjetaData.Registrar(entidad);

                return new ResponseEntity("Registro un Medio de Pago satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity ActualizarTipoTarjeta(SRV_TIPO_TARJETA entidad)
        {
            try
            {
                var tarjetaReg = _tipoTarjetaData.BuscarPorId(entidad.CODTIPTAR);

                tarjetaReg.NOMTIPTAR = entidad.NOMTIPTAR;
                tarjetaReg.ESTREG = entidad.ESTREG;

                this._tipoTarjetaData.Actualizar(tarjetaReg);

                return new ResponseEntity("Se actualizo un Medio de Pago satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity EliminarTipoTarjeta(int id)
        {
            try
            {
                this._tipoTarjetaData.Eliminar(id);
                return new ResponseEntity("Se elimino el Medio de Pago seleccionado satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public IEnumerable<SRV_TIPO_TARJETA> ListarTodo()
        {
            return this._tipoTarjetaData.ListarTodo();
        }

        public IEnumerable<SRV_TIPO_TARJETA> ListarTiposTarjeta(SRV_TIPO_TARJETA entidad)
        {
            return this._tipoTarjetaData.ListarTiposTarjeta(entidad);
        }
    }
}
