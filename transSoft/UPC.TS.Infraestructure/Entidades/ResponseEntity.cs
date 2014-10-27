using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.TS.Infraestructure.Entidades
{
    public class ResponseEntity
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public ResponseEntity(string _message, bool _success = false, object _data = null) {
            this.Message = _message;
            this.Success = _success;
            this.Data = _data;
        }
    }
}

