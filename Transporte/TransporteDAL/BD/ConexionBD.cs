
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDAL.CONTRATOS;

namespace TransporteDAL.BD
{
    public class ConexionBD : IConexion
    {
        /// <summary>
        /// Clase para la conexion a la bd supcriptionBD
        /// </summary>
        /// 
        private SqlConnection Conn;
        private readonly IConfiguration _configuration;
  


        public ConexionBD(
            IConfiguration configuration = null
            )
        {
            _configuration = configuration;
         

        }


        #region CadenaConexion
        //  private SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        //private string connectionString = _configuration.GetConnectionString("ConnDaviReca");

        // private SqlConnection Con = new SqlConnection(message);
        #endregion

        #region MethodOpen 
        //public SqlConnection OpenConexion()
        //{
        //    string pro = _configuration.GetConnectionString("");
        //    if (Con.State == ConnectionState.Closed)
        //        Con.Open();
        //    return Con;
        //}
        #endregion

       

        public SqlConnection OpenConexion()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                Conn = new SqlConnection(connectionString);
                Conn.Open();
                return Conn;

            }
            catch (Exception )
            {
                throw;
            }
        }

   

        #region MethodClose
        //public SqlConnection CloseConexion()
        //{
        //    if (Con.State == ConnectionState.Open)
        //        Con.Close();
        //    return Con;
        //}
        public SqlConnection CloseConexion()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                Conn = new SqlConnection(connectionString);
                Conn.Close();
                return Conn;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
