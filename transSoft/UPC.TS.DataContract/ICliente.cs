using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.Infraestructure.Contratos;
using UPC.TS.Entities;

namespace UPC.TS.DataContract
{
    public interface ICliente : IOperacionesCRUD<SRV_CLIENTE> 
    {
        SRV_CLIENTE ObtenerUsuarioPorCorreo(string correo);
    }
}
