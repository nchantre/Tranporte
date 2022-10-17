
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
using TransporteDAL.CONTRATOS;

namespace TransporteDAL.DAL
{
    public class EmpleadoDAL : IEmpleado
    {
        #region Variables
        private readonly IConexion _conexion;
        //private readonly Empleado _companyModels;

        #endregion

        #region Constructor
        public EmpleadoDAL(IConexion conexion
                          //Empleado companyModels
            )
        {
            _conexion = conexion;
            //_companyModels = companyModels;
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
                 Empleado entity = new Empleado();
                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spEmpleadoAllId";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmEmpleadoId", SqlDbType.Int).Value = EmpleadoId;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            entity.IdEmpleado = Convert.ToInt32(read["IdEmpleado"]);
                            entity.Origen = read["Origen"].ToString();
                            entity.TiempoTranscurrido = Convert.ToInt32(read["TiempoTranscurrido"]);
                            entity.NombrePasajero = read["NombrePasajero"].ToString();
                            entity.PlacaVehiculo = read["PlacaVehiculo"].ToString();
                            entity.HoraViaje = read["HoraViaje"].ToString();
                        }
                    }
                }
                _conexion.CloseConexion();
                return entity;
            }
        }
        #endregion

        #region InsertEmpleado
        public string AddEmpleado(Empleado entity)
        {
            //Empleado entity = new Empleado();
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = _conexion.OpenConexion();
                    comando.CommandText = "spEmpleadoInsert";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Origen", SqlDbType.VarChar, 50).Value = Convert.ToString(entity.Origen);
                    comando.Parameters.Add("@TiempoTranscurrido", SqlDbType.Int).Value = entity.TiempoTranscurrido;
                    comando.Parameters.Add("@NombrePasajero", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.NombrePasajero); ;
                    comando.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.PlacaVehiculo);
                    comando.Parameters.Add("@HoraViaje", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.HoraViaje);
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
        public void UpEmpleado(Empleado entity)
        {

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spEmpleadoUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = (entity.IdEmpleado);
                comando.Parameters.Add("@Origen", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.Origen);
                comando.Parameters.Add("@TiempoTranscurrido", SqlDbType.Int).Value = entity.TiempoTranscurrido;
                comando.Parameters.Add("@NombrePasajero", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.NombrePasajero);
                comando.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.PlacaVehiculo); ;
                comando.Parameters.Add("@HoraViaje", SqlDbType.VarChar, 70).Value = Convert.ToString(entity.HoraViaje);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                _conexion.CloseConexion();


            }

        }

        #endregion

        #region DeleteEmpleado
        public void DeleteEmpleado(Empleado entity)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = _conexion.OpenConexion();
                comando.CommandText = "spEmpleadoDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = (entity.IdEmpleado);
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
                comando.CommandText = "spEmpleadoAll";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                             Empleado entity = new Empleado();
                            entity.IdEmpleado = Convert.ToInt32(read["IdEmpleado"]);
                            entity.Origen = read["Origen"].ToString();
                            entity.TiempoTranscurrido = Convert.ToInt32(read["TiempoTranscurrido"]);
                            entity.NombrePasajero = read["NombrePasajero"].ToString();
                            entity.PlacaVehiculo = read["PlacaVehiculo"].ToString();
                            entity.HoraViaje = read["HoraViaje"].ToString();
                            items.Add(entity);
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
