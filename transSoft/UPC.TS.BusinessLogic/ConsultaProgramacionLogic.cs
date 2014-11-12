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
    public class ConsultaProgramacionLogic : IConsultaProgramacionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsultaProgramacion _consultaProgramacionData;
        public ConsultaProgramacionLogic()
        {
            this._uow = new UnitOfWork();
            this._consultaProgramacionData = new ConsultaProgramacion(_uow);
        }

        public IEnumerable<VWCONSULTAPROGRAMACION> ListarProgramacion(string ORITAR, string DESTAR, string FECSALPRO)
        {
            return _consultaProgramacionData.ListarProgramacion(ORITAR, DESTAR, FECSALPRO);
        }
    }
}
