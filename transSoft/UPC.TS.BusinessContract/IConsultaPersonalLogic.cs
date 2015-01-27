using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Entities;
using UPC.TS.Infraestructure;
using UPC.TS.Infraestructure.Entidades;

namespace UPC.TS.BusinessContract
{
    public interface IConsultaPersonalLogic
    {
        IEnumerable<SRV_VW_CONSULTA_PERSONAL> ListarPersonal(string DNIPER, string LOGUSU);
    }
}
