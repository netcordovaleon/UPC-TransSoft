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
        error,
        [Description("Respuesta tipo Correcto")]
        success,
        [Description("Respuesta tipo Advertencia")]
        alert,
        [Description("Respuesta tipo Informativa")]
        info
    }
}
