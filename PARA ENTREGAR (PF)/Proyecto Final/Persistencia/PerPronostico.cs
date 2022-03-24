using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    public class PerPronostico
    {        
        public void Registrar(Pronostico pronostico)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);            
            SqlCommand command = new SqlCommand("sp_RegistrarPronostico", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("PLluvia", pronostico.ProbabilidadLluvia));
            command.Parameters.Add(new SqlParameter("PTormenta", pronostico.ProbabilidadTormenta));
            command.Parameters.Add(new SqlParameter("TMinima", pronostico.TemperaturaMinima));
            command.Parameters.Add(new SqlParameter("TMaxima", pronostico.TemperaturaMaxima));
            command.Parameters.Add(new SqlParameter("fechaHora", pronostico.FechaHora));
            command.Parameters.Add(new SqlParameter("VelViento", pronostico.VelocidadViento));
            command.Parameters.Add(new SqlParameter("TipoCielo", pronostico.TipoCielo));
            command.Parameters.Add(new SqlParameter("CodigoUsuario", pronostico.Usuario.LogueoUsuario));
            command.Parameters.Add(new SqlParameter("CodigoPais", pronostico.Ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("CodigoCiudad", pronostico.Ciudad.CodigoCiudad));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);            

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("No existe usuario con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("No existe ciudad con el código ingresado.");

                else if (retorno == -3)
                    throw new Exception("No se pudo registrar el pronóstico.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Pronostico> PronosticosporCiudad(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            
            SqlCommand command = new SqlCommand("sp_PronosticosCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("CodigoCiudad", ciudad.CodigoCiudad));

            SqlDataReader reader;
            List<Pronostico> pronosticos = new List<Pronostico>();

            PerUsuario perUsuario = new PerUsuario();
            
            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = perUsuario.Buscar(reader["CodigoUsuario"].ToString());
                    
                    Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["Codigo"].ToString()),
                                                    Convert.ToInt32(reader["TMaxima"].ToString()),
                                                    Convert.ToInt32(reader["TMinima"].ToString()),
                                                    Convert.ToInt32(reader["VelocidadViento"].ToString()),
                                                    reader["TipoCielo"].ToString(),
                                                    Convert.ToInt32(reader["Plluvia"].ToString()),
                                                    Convert.ToInt32(reader["Ptormenta"].ToString()),
                                                    Convert.ToDateTime(reader["FechaHora"].ToString()),
                                                    usuario, ciudad);
                    pronosticos.Add(pronostico);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {                
                connection.Close();
            }
            return pronosticos;
        }
        public List<Pronostico> PronosticosporFecha(DateTime fecha)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);            
            SqlCommand command = new SqlCommand("sp_pronosticoFechaIngresada", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("fecha", fecha));

            SqlDataReader reader;
            List<Pronostico> pronosticos = new List<Pronostico>();

            PerUsuario perUsuario = new PerUsuario();
            PerCiudad perCiudad = new PerCiudad();            

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = perUsuario.Buscar(reader["CodigoUsuario"].ToString());
                    Ciudad ciudad = perCiudad.Buscar(reader["CodigoPais"].ToString(),
                                                     reader["CodigoCiudad"].ToString());

                    Pronostico pronostico = new Pronostico(Convert.ToInt32(reader["Codigo"].ToString()),
                                                    Convert.ToInt32(reader["TMaxima"].ToString()),
                                                    Convert.ToInt32(reader["TMinima"].ToString()),
                                                    Convert.ToInt32(reader["VelocidadViento"].ToString()),
                                                    reader["TipoCielo"].ToString(),
                                                    Convert.ToInt32(reader["Plluvia"].ToString()),
                                                    Convert.ToInt32(reader["Ptormenta"].ToString()),
                                                    Convert.ToDateTime(reader["FechaHora"].ToString()),
                                                    usuario, ciudad);
                    pronosticos.Add(pronostico);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {                
                connection.Close();
            }
            return pronosticos;
        }                
    }
}
