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
//using UPC.TS.BusinessLogic.Properties;
namespace UPC.TS.BusinessLogic
{
    public class ContactenosLogic : IContactenosLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactenos _contactenosData;
        public ContactenosLogic(){
            this._uow = new UnitOfWork();
            this._contactenosData = new ContactenosData(_uow);
        }

        public ResponseEntity GrabarContacto(contactenos entidad)
        {
            try {
                if (entidad.idcon.Equals(0))
                    _contactenosData.Registrar(entidad);
                else
                    _contactenosData.Actualizar(entidad);
                return new ResponseEntity("Se registro satisfactoriamente", true);
            } catch (Exception) {
                //return new ResponseEntity(Resources.MensajeError);
                return null;
            }
        }
    }
}
