using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.TS.Infraestructure.Contratos
{
    public interface IOperacionesCRUD<T>
    {
        T Registrar(T entidad);
        T Actualizar(T entidad);
        bool Eliminar(int id);
        T BuscarPorId(int id);
        IEnumerable<T> ListarTodo();
    }
}
