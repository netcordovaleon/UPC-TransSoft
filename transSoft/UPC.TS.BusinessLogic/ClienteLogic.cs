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
    public class ClienteLogic : IClienteLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ICliente _clienteData;
        public ClienteLogic()
        {
            this._uow = new UnitOfWork();
            this._clienteData = new ClienteData(_uow);
        }
        public CLIENTE ObtenerUsuarioPorCorreo(string correo)
        {
            var result = _clienteData.ObtenerUsuarioPorCorreo(correo);
            return result;
        }
    }
}
