using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Infraestructure;

namespace UPC.TS.DataImplement
{
    public class ConsultaPersonalData : BaseRepository<SRV_VW_CONSULTA_PERSONAL>, IConsultaPersonal
    {
        public ConsultaPersonalData(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<SRV_VW_CONSULTA_PERSONAL> ListarPersonal(string DNIPER, string LOGUSU)
        {
            if (!string.IsNullOrEmpty(DNIPER) && !string.IsNullOrEmpty(LOGUSU))
                return this.GetMany(c => c.DNIPER.Equals(DNIPER) && c.LOGUSU.Equals(LOGUSU));
            if (string.IsNullOrEmpty(DNIPER) && !string.IsNullOrEmpty(LOGUSU))
                return this.GetMany(c => c.LOGUSU.Equals(LOGUSU));
            if (!string.IsNullOrEmpty(DNIPER) && string.IsNullOrEmpty(LOGUSU))
                return this.GetMany(c => c.DNIPER.Equals(DNIPER));
            
            return this.GetMany();
        }
    }
}
