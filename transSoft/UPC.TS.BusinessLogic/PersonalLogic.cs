using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UPC.TS.BusinessContract;
using UPC.TS.DataContract;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataImplement;
using UPC.TS.DataImplement.Infraestructura;
using UPC.TS.Entities;
using UPC.TS.Infraestructure.Entidades;
using UPC.TS.Infraestructure.Enum;
using UPC.TS.Infraestructure.Mensajes.Respuesta;
namespace UPC.TS.BusinessLogic
{
    public class PersonalLogic : IPersonalLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IPersonal _personalData;
        private readonly IUsuario _usuarioData;
        public PersonalLogic()
        {
            this._uow = new UnitOfWork();
            this._personalData = new PersonalData(_uow);
            this._usuarioData = new UsuarioData(_uow);
        }

        public SRV_PERSONAL BuscarPorId(int id)
        {
            return this._personalData.BuscarPorId(id);
        }

        public ResponseEntity RegistrarPersonalUsuario(SRV_PERSONAL personal, SRV_USUARIO usuario)
        {
            try
            {
                var existeUsuario = _usuarioData.ExisteUsuarioReg(usuario);
                if (existeUsuario)
                {
                    return new ResponseEntity("El correo que ingreso ya se encuentra registrado");
                }

                var existePersonal = _personalData.ExistePersonal(personal);
                if (existePersonal)
                {
                    return new ResponseEntity("El DNI que ingreso ya se encuentra registrado");
                }

                using(var scope = new TransactionScope())
                {
                    usuario.CODPER = (int)PerfilesSistema.USUARIOSISTEMA;
                    var usuarioReg = _usuarioData.Registrar(usuario);

                    personal.CODUSU = usuarioReg.CODUSU;

                    var personalReg = _personalData.Registrar(personal);

                    scope.Complete();
                }

                return new ResponseEntity("Registro un personal satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity ActualizarPersonalUsuario(SRV_PERSONAL personal, SRV_USUARIO usuario)
        {
            try
            {   
                var personalReg = _personalData.BuscarPorId(personal.CODPER);
                
                using (var scope = new TransactionScope())
                {
                    if(!string.IsNullOrEmpty(usuario.CLAUSU))
                    {
                        var usuarioReg = _usuarioData.BuscarPorId(usuario.CODUSU);
                        usuarioReg.CLAUSU = usuario.CLAUSU;
                        _usuarioData.Actualizar(usuarioReg);
                    }
                    
                    personalReg.NOMPER = personal.NOMPER;
                    personalReg.APEPER = personal.APEPER;

                    _personalData.Actualizar(personalReg);

                    scope.Complete();
                }

                return new ResponseEntity("Se actualizo un personal satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }

        public ResponseEntity EliminarPersonal(int id)
        {
            try
            {
                this._personalData.Eliminar(id);
                return new ResponseEntity("Se elimino el Personal seleccionado satisfactoriamente", true);
            }
            catch (Exception)
            {
                return new ResponseEntity(Response.ErrorGeneral);
            }
        }
    }
}
