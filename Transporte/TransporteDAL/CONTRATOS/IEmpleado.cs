using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDAL.DAL;
using TransporteModel.Model;

namespace TransporteDAL.CONTRATOS
{
    public interface IEmpleado 
    {

         Empleado GetAllEmpleadoId(int EmpleadoId);
         string AddEmpleado(Empleado entity);
         void UpEmpleado( Empleado entity);
         void DeleteEmpleado(Empleado entity);
         List<Empleado> GetAllEmpleado();

    }
}
