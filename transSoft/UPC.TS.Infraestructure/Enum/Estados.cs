using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.TS.Infraestructure.Enum
{
    public class Estados
    {
        public enum Auditoria {
            [Description("Registro activo para el Sistema")]
            Activo = 1,
            [Description("Registro inactivo para el Sistema")]
            Inactivo = 0
        }


    }
}
