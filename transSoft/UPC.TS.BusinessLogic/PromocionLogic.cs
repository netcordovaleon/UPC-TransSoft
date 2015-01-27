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
    public class PromocionLogic : IPromocionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IPromocion _promocionData;
        public PromocionLogic()
        {
            this._uow = new UnitOfWork();
            this._promocionData = new PromocionData(_uow);
        }

        public ResponseEntity GrabarPromocion(SRV_PROMOCION entidad)
        {
            try
            {
                if(entidad.PORDESC <= 0)
                    return new ResponseEntity("Ingresar el Porcentaje de Descuento");
                
                if (entidad.CODPROM.Equals(0))
                    _promocionData.Registrar(entidad);
                else
                {
                    var promocion = _promocionData.BuscarPorId(entidad.CODPROM);
                    promocion.DESPROM = entidad.DESPROM;
                    promocion.PORDESC = entidad.PORDESC;
                    promocion.FECINI = entidad.FECINI;
                    promocion.FECFIN = entidad.FECFIN;
                    promocion.ESTREG = "1";
                    _promocionData.Actualizar(promocion);
                }
                return new ResponseEntity("Se grabo los datos de la Promocion satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity EliminarPromocion(int id)
        {
            try
            {
                _promocionData.Eliminar(id);
                return new ResponseEntity("Se elimino el Descuento seleccionado satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public SRV_PROMOCION BuscarPorId(int id)
        {
            return _promocionData.BuscarPorId(id);
        }

        public IEnumerable<SRV_PROMOCION> ListarPromocion()
        {
            return _promocionData.ListarTodo();
        }


        public IEnumerable<SRV_PROMOCION> ListarPromocionFiltro(SRV_PROMOCION entidad)
        {
            return _promocionData.ListarPromocionFiltro(entidad);
        }
    }
}
