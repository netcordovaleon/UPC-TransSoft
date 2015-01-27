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
        SRV_USUARIO BuscarPorId(int id);
        ResponseEntity IngresarSistema(SRV_USUARIO entidad);
        ResponseEntity AgregarUsuarioReserva(SRV_USUARIO usuario, SRV_CLIENTE cliente);

        ResponseEntity Registrar(SRV_USUARIO usuario);
    }
}
