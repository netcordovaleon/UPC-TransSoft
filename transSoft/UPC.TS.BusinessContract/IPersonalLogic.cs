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
    public interface IPersonalLogic
    {
        SRV_PERSONAL BuscarPorId(int id);
        ResponseEntity RegistrarPersonalUsuario(SRV_PERSONAL personal, SRV_USUARIO usuario);
        ResponseEntity ActualizarPersonalUsuario(SRV_PERSONAL personal, SRV_USUARIO usuario);
        ResponseEntity EliminarPersonal(int id);
    }
}
