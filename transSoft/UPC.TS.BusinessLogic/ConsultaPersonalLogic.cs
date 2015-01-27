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
    public class ConsultaPersonalLogic : IConsultaPersonalLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsultaPersonal _consultaPersonalData;
        public ConsultaPersonalLogic()
        {
            this._uow = new UnitOfWork();
            this._consultaPersonalData = new ConsultaPersonalData(_uow);
        }

        public IEnumerable<SRV_VW_CONSULTA_PERSONAL> ListarPersonal(string DNIPER, string LOGUSU)
        {
            return this._consultaPersonalData.ListarPersonal(DNIPER, LOGUSU);
        }
    }
}
