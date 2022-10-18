using System.Collections.Generic;
using System.Threading.Tasks;
using TrasnporteAdmin.Models;

namespace TrasnporteAdmin.Servicios
{
    public interface IServicio_API
    {
        Task<List<EmpleadoViewModel>> Lista();

        Task<EmpleadoViewModel> Obtener(int idProducto);

        Task<bool> Guardar(EmpleadoViewModel objeto);

        Task<bool> Editar(EmpleadoViewModel objeto);

        Task<bool> Eliminar(int idProducto);
    
    }
}
