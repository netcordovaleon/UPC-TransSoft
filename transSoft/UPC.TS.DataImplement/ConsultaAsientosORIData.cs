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
    public class ConsultaAsientosORIData : BaseRepository<SRV_VW_ASIENTOS_RESERVADOSORI>, IConsultaAsientosORI
    {
        public ConsultaAsientosORIData(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<SRV_VW_ASIENTOS_RESERVADOSORI> ListarAsientosORI(int CODPRO)
        {
            return this.GetMany(c => c.CODPRO == CODPRO);
        }
    }
}
