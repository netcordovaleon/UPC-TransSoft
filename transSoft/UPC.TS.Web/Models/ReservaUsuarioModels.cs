using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.TS.Web.Models
{
    public class ReservaUsuarioModels
    {
        public int CODPRO_ORI { get; set; }
        public int CODPRO_DES { get; set; }
        public UsuarioModels usuario { get; set; }
        public ReservaUsuarioModels() {
            this.usuario = new UsuarioModels();
        }
    }
}