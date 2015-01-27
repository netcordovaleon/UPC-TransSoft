using System;
using System.Transactions;
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
using UPC.TS.Infraestructure.Enum;

namespace UPC.TS.BusinessLogic
{
    public class UsuarioLogic : IUsuarioLogic, IDisposable
    {

        private readonly IUnitOfWork _uow;
        private readonly IUsuario _usuarioData;
        private readonly ICliente _clienteData;
        public UsuarioLogic()
        {
            this._uow = new UnitOfWork();
            this._usuarioData = new UsuarioData(_uow);
            this._clienteData = new ClienteData(_uow);
        }

        public SRV_USUARIO BuscarPorId(int id)
        {
            return this._usuarioData.BuscarPorId(id);
        }

        public ResponseEntity IngresarSistema(SRV_USUARIO entidad)
        {
            try
            {
                var acceso = _usuarioData.IngresarSistema(entidad);
                if (acceso)
                    return new ResponseEntity("Bienvenido al sistema", true);
                else
                    return new ResponseEntity("El usuario o password que ingreso no son correctos");
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
             
        }
        public ResponseEntity AgregarUsuarioReserva(SRV_USUARIO usuario, SRV_CLIENTE cliente)
        {
            using (TransactionScope tran = new TransactionScope()) { 
                try {

                    var existeUsuario = _usuarioData.ExisteUsuarioReg(usuario);
                    if (existeUsuario) {
                        tran.Dispose();
                        return new ResponseEntity("El correo que ingreso ya se encuentra registrado");
                    }
                    usuario.CODPER = (int)PerfilesSistema.CLIENTESISTEMA;
                    var usuarioReg = _usuarioData.Registrar(usuario);
                    cliente.CODUSU = usuarioReg.CODUSU;
                    _clienteData.Registrar(cliente);
                    tran.Complete();
                    return new ResponseEntity("Registro un usuario satisfactoriamente", true);
                }
                catch (Exception)
                {
                    tran.Dispose();
                    return new ResponseEntity(Response.ErrorGeneral);
                }
            }
        }

        public ResponseEntity Registrar(SRV_USUARIO usuario)
        {
            try
            {

                var existeUsuario = _usuarioData.ExisteUsuarioReg(usuario);
                if (existeUsuario)
                {
                    return new ResponseEntity("El correo que ingreso ya se encuentra registrado");
                }
                usuario.CODPER = (int)PerfilesSistema.USUARIOSISTEMA;
                var usuarioReg = _usuarioData.Registrar(usuario);
                return new ResponseEntity("Registro un usuario satisfactoriamente", true, usuarioReg.CODUSU);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        void IDisposable.Dispose()
        {
            _uow.Dispose();
        }
    }
}
