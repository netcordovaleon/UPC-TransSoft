using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.Infraestructure.Constantes;
namespace UPC.TS.Infraestructure.Entidades
{
    public class ResponseEntity
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public TypeResponse Type { get; set; }


        //MENSAJE ERROR
        public ResponseEntity(string _message) {
            this.Message = _message;
            this.Success = false;
        }

        //MENSAJE PERSONALIZADO 1
        public ResponseEntity(string _message, TypeResponse _type, bool _success = false)
        {
            this.Message = _message;
            this.Success = _success;
            this.Type = _type;
        }

        //MENSAJE PERSONALIZADO 2
        public ResponseEntity(string _message, bool _success = false, object _data = null, Enum _type = null) {
            this.Message = _message;
            this.Success = _success;
            this.Data = _data;
            this.Type = TypeResponse.Error;
        }
    }
}

