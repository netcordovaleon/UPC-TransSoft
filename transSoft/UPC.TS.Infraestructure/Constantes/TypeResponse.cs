using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.TS.Infraestructure.Constantes
{
    public enum TypeResponse {
        [Description("Respuesta tipo Error")]
        Error = 0,
        [Description("Respuesta tipo Correcto")]
        Success = 1,
        [Description("Respuesta tipo Advertencia")]
        Warning = 2,
        [Description("Respuesta tipo Informativa")]
        Information = 2
    }

}
