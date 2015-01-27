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
    public class ConsultaReservaLogic : IConsultaReservaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsultaReserva _consultaReservaData;
        public ConsultaReservaLogic()
        {
            this._uow = new UnitOfWork();
            this._consultaReservaData = new ConsultaReservaData(_uow);
        }

        public IEnumerable<SRV_VW_RESERVAS> ObtenerReservasUsuario(string CORCLI, int? codReserva = null)
        {
            return _consultaReservaData.ObtenerReservasUsuario(CORCLI, codReserva);
        }

        public IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuario(string correoCliente)
        {
            return _consultaReservaData.ListarReservaPorUsuario(correoCliente);
        }

        public IEnumerable<SRV_VW_RESERVAS> ListarReservaPorUsuarioyReserva(int codReserva, string correoCliente)
        {
            return _consultaReservaData.ListarReservaPorUsuarioyReserva(codReserva, correoCliente);
        }
    }
}
