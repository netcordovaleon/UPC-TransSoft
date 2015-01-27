using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.Infraestructure.Contratos;
using UPC.TS.Infraestructure.Entidades;
using UPC.TS.Entities;

namespace UPC.TS.DataContract
{
    public interface IPersonal : IOperacionesCRUD<SRV_PERSONAL> 
    {
        bool ExistePersonal(SRV_PERSONAL entidad);
    }
}
