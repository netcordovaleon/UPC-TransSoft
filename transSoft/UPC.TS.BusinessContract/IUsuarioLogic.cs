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
    public interface IUsuarioLogic 
    {
        ResponseEntity IngresarSistema(USUARIO entidad);
        ResponseEntity AgregarUsuarioReserva(USUARIO usuario, CLIENTE cliente);
    }
}
