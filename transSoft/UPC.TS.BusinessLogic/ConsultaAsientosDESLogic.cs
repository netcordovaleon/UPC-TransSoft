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
    public class ConsultaAsientosDESLogic : IConsultaAsientosDESLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsultaAsientosDES _consultaDES;
        public ConsultaAsientosDESLogic()
        {
            this._uow = new UnitOfWork();
            this._consultaDES = new ConsultaAsientosDESData(_uow);
        }
        public IEnumerable<SRV_VW_ASIENTOS_RESERVADOSDES> ListarAsientosDES(int codProgramacion)
        {
            return _consultaDES.ListarAsientosDES(codProgramacion);
        }
    }
}
