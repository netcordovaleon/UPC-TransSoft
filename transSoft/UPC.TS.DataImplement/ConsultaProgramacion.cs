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
    public class ConsultaProgramacion : BaseRepository<VWCONSULTAPROGRAMACION>, IConsultaProgramacion
    {
        public ConsultaProgramacion(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<VWCONSULTAPROGRAMACION> ListarProgramacion(string ORITAR, string DESTAR, string FECSALPRO)
        {
            var result = this.GetMany(c => c.ORITAR == ORITAR && c.DESTAR == DESTAR && c.FECSALPRO == FECSALPRO);
            return result;
        }
    }
}
