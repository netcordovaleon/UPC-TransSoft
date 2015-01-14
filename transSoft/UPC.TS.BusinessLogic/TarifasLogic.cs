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

        public ResponseEntity GrabarTarifa(SRV_TARIFA entidad)
        {
            try
            {
                if (entidad.CODTAR.Equals(0))
                    _tarifasData.Registrar(entidad);
                else
                    _tarifasData.Actualizar(entidad);
                return new ResponseEntity("Se grabo los datos de la tarifa satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity EliminarTarifa(int id)
        {
            try
            {
                _tarifasData.Eliminar(id);
                return new ResponseEntity("Se elimino la tarifa seleccionada satisfactoriamente", true);
            } catch (Exception) {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public SRV_TARIFA BuscarPorId(int id)
        {
            return _tarifasData.BuscarPorId(id);
        }

        public IEnumerable<SRV_TARIFA> ListarTarifas()
        {
            return _tarifasData.ListarTodo();
        }

        public IEnumerable<SRV_TARIFA> ListarOrigen()
        {
            return _tarifasData.ListarOrigen();
        }

        public IEnumerable<SRV_TARIFA> ListarDestino()
        {
            return _tarifasData.ListarDestino();
        }


        public IEnumerable<SRV_TARIFA> ListarTarifaFiltro(SRV_TARIFA entidad)
        {
            return _tarifasData.ListarTarifaFiltro(entidad);
        }
    }
}
