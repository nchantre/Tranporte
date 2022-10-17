using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDAL.BD;
using TransporteModel.Model;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;

namespace TransporteDAL.DAL
{
    public class EmpleadoDAL
    {
        #region Variables
        private readonly ConexionBD _conexion;
        private readonly Empleado _companyModels;

        #endregion

        #region Constructor
        public EmpleadoDAL(ConexionBD conexion,
                          Empleado companyModels)
        {
            _conexion = conexion;
            _companyModels = companyModels;
        }

        #endregion

        ///<summary >
        ///  Data Access Layer (DAL)
        /// </summary>

        #region InstaObj
        // private Conexion conexion = new Conexion();
        // private DataTable tb = new DataTable();
        #endregion

        #region Variable 
        // private SqlDataReader read;
        #endregion

        #region GetAllEmpleadoId
        public Empleado GetAllEmpleadoId(int EmpleadoId)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                // CompanyModels entity = new CompanyModels();
                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spCompanyAllId";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmCompanyId", SqlDbType.Int).Value = EmpleadoId;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            _companyModels.IdEmpleado = Convert.ToInt32(read["IdEmpleado"]);
                            _companyModels.Origen = read["Origen"].ToString();
                            _companyModels.TiempoTranscurrido = Convert.ToInt32(read["TiempoTranscurrido"]);
                            _companyModels.NombrePasajero = read["NombrePasajero"].ToString();
                            _companyModels.PlacaVehiculo = read["PlacaVehiculo"].ToString();
                            _companyModels.HoraViaje = read["HoraViaje"].ToString();
                        }
                    }
                }
                _conexion.CloseConexion();
                return _companyModels;
            }
        }
        #endregion

        #region InsertEmpleado
        public string AddEmpleado()
        {
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = _conexion.OpenConexion();
                    comando.CommandText = "spCompanyInsert";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Origen", SqlDbType.VarChar, 50).Value = Convert.ToString(_companyModels.Origen);
                    comando.Parameters.Add("@TiempoTranscurrido", SqlDbType.Int).Value = _companyModels.TiempoTranscurrido;
                    comando.Parameters.Add("@NombrePasajero", SqlDbType.VarChar, 70).Value = Convert.ToString(_companyModels.NombrePasajero); ;
                    comando.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 70).Value = Convert.ToString(_companyModels.PlacaVehiculo);
                    comando.Parameters.Add("@HoraViaje", SqlDbType.VarChar, 70).Value = Convert.ToString(_companyModels.HoraViaje);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    _conexion.CloseConexion();

                }

            }
            catch (FaultException fex)
            {
                mensaje = "Error" + fex;
            }

            return mensaje;
        }

        #endregion

        #region EditEmpleado
        public void UpEmpleado()
        {

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spCompanyUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Origen", SqlDbType.VarChar,70).Value = Convert.ToString(_companyModels.Origen);
                comando.Parameters.Add("@TiempoTranscurrido", SqlDbType.Int).Value = _companyModels.TiempoTranscurrido;
                comando.Parameters.Add("@NombrePasajero", SqlDbType.VarChar,70).Value = Convert.ToString(_companyModels.NombrePasajero);
                comando.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 70).Value = Convert.ToString(_companyModels.PlacaVehiculo); ;
                comando.Parameters.Add("@HoraViaje", SqlDbType.VarChar, 70).Value = Convert.ToString(_companyModels.HoraViaje);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                _conexion.CloseConexion();


            }

        }

        #endregion

        #region DeleteEmpleado
        public void DeleteCompany(int EmpleadoId)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spCompanyDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmCompanyId", SqlDbType.Int).Value = (EmpleadoId);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                _conexion.CloseConexion();

            }


        }

        #endregion

        #region GetAllEmpleado
        public List<Empleado> GetAllEmpleado()
        {


            using (SqlCommand comando = new SqlCommand())
            {
                List<Empleado> items = new List<Empleado>();

                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spCompanyAll";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            // CompanyModels entity = new CompanyModels();
                            _companyModels.IdEmpleado = Convert.ToInt32(read["IdEmpleado"]);
                            _companyModels.Origen = read["Origen"].ToString();
                            _companyModels.TiempoTranscurrido = Convert.ToInt32(read["TiempoTranscurrido"]);
                            _companyModels.NombrePasajero = read["NombrePasajero"].ToString();
                            _companyModels.PlacaVehiculo = read["PlacaVehiculo"].ToString();
                            _companyModels.HoraViaje = read["HoraViaje"].ToString();
                            items.Add(_companyModels);
                        }

                    }
                }
                // tb.Load(read);
                _conexion.CloseConexion();
                return items;
            }

        }
        #endregion


    }
}
