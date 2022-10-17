using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDAL.BD
{
    public class ConexionBD
    {
        /// <summary>
        /// Clase para la conexion a la bd supcriptionBD
        /// </summary>
        /// 
        protected SqlConnection Conn;
        //private readonly IConfiguration _configuration;

        //public ConexionBD(
        //    IConfiguration configuration = null
        //    )
        //{
        //_configuration = configuration;

        //}

        //protected void conectar() {
        //    try
        //    {
        //        Conn = new SqlConnection("Server=DESKTOP-FT1VQS5\\chan;DataBase=supcriptionDB;Integrated Security=true");
        //        Conn.Open();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {

        //    }
        
        //}



        #region CadenaConexion
         //  private SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        private SqlConnection Con = new SqlConnection("Server=DESKTOP-FT1VQS5\\chan;DataBase=supcriptionDB;Integrated Security=true");
        #endregion

        #region MethodOpen 
        public SqlConnection OpenConexion()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            return Con;
        }
        #endregion

        #region MethodClose
        public SqlConnection CloseConexion()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            return Con;
        }
        #endregion


    }
}
