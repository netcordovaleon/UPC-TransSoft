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
    public class ConsultaAsientosDESData : BaseRepository<SRV_VW_ASIENTOS_RESERVADOSDES>, IConsultaAsientosDES
    {
        public ConsultaAsientosDESData(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<SRV_VW_ASIENTOS_RESERVADOSDES> ListarAsientosDES(int CODPRO)
        {
            return this.GetMany(c => c.CODPRO == CODPRO);
        }
    }
}
