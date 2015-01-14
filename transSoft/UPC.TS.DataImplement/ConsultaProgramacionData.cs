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
    public class ConsultaProgramacionData : BaseRepository<SRV_VW_CONSULTA_PROGRAMACION>, IConsultaProgramacion
    {
        public ConsultaProgramacionData(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<SRV_VW_CONSULTA_PROGRAMACION> ListarProgramacion(string ORITAR, string DESTAR, string FECSALPRO)
        {
            var result = this.GetMany(c => c.ORITAR == ORITAR && c.DESTAR == DESTAR && c.FECSALPRO == FECSALPRO);
            return result;
        }

    }
}
