using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement.Infraestructura;
namespace UPC.TS.DataImplement
{
    public class ContactenosData : BaseRepository<contactenos>, IContactenos
    {

        public ContactenosData(IUnitOfWork unit) : base(unit) { }

        public bool grabarContactenos(contactenos entity)
        {
            try {   
                this.Insert(entity);
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}
