
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDAL.CONTRATOS
{
    public interface IConexion
    {
        SqlConnection OpenConexion();
        SqlConnection CloseConexion();
       
    }
}
