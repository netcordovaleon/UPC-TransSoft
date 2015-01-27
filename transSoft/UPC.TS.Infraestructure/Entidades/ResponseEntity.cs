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
        public string Title { get; set; }
        public string TypeResponse { get; set; }
        public TypeResponse Type { get; set; }

        //MENSAJE ERROR

        public ResponseEntity() { }
        public ResponseEntity(string _message) {
            this.Message = _message;
            this.Success = false;
            this.TypeResponse = Infraestructure.Constantes.TypeResponse.error.ToString();
            this.Title = getTitle(Infraestructure.Constantes.TypeResponse.error);
        }

        public ResponseEntity(string _message, bool _success = false, object _data = null)
        {
            this.Message = _message;
            this.Success = _success;
            this.Data = _data;
            if (_success)
            {
                this.TypeResponse = Infraestructure.Constantes.TypeResponse.success.ToString();
                this.Title = getTitle(Infraestructure.Constantes.TypeResponse.success);
            }
            else {
                this.TypeResponse = Infraestructure.Constantes.TypeResponse.error.ToString();
                this.Title = getTitle(Infraestructure.Constantes.TypeResponse.error);
            }
        }

        //MENSAJE PERSONALIZADO 1
        public ResponseEntity(string _message, TypeResponse _type, object _data)
        {
            this.Message = _message;
            this.Success = false;
            this.TypeResponse = _type.ToString();
            this.Data = _data;
            this.Title = getTitle(_type);
        }

        public string getTitle(TypeResponse _type) {
            string tituloAlertPNotify = string.Empty;
            if (_type.ToString() == "error")
                tituloAlertPNotify = Constantes.TitleResponse.error;
            if (_type.ToString() == "alert")
                tituloAlertPNotify = Constantes.TitleResponse.alert;
            if (_type.ToString() == "info")
                tituloAlertPNotify = Constantes.TitleResponse.info;
            if (_type.ToString() == "success")
                tituloAlertPNotify = Constantes.TitleResponse.success;
            return tituloAlertPNotify;
        }
    }
}

