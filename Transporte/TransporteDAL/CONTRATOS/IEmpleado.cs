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
        //string AddEmpleado();
        //void UpEmpleado();
        //void DeleteCompany(int EmpleadoId);
        //List<Empleado> GetAllEmpleado();

    }
}
