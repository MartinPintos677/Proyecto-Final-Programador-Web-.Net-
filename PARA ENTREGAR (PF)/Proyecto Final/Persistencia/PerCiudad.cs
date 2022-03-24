using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    public class PerCiudad
    {
        public Ciudad Buscar(string codigoPais, string codigoCiudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_BuscarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", codigoPais));
            command.Parameters.Add(new SqlParameter("CodigoCiudad", codigoCiudad));

            SqlDataReader reader;

            PerPais perPais = new PerPais();
            Ciudad ciudad = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Pais pais = perPais.Buscar(reader["CodigoPais"].ToString());

                    ciudad = new Ciudad(reader["CodigoCiudad"].ToString(),
                                        reader["NombreCiudad"].ToString(),
                                        pais);
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
            return ciudad;
        }
        public List<Ciudad> TodasCiudades()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_ListadodeCiudades", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader;

            List<Ciudad> ciudades = new List<Ciudad>();
            PerPais perPais = new PerPais();

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pais pais = perPais.Buscar(reader["CodigoPais"].ToString());

                    Ciudad ciudad = new Ciudad(reader["CodigoCiudad"].ToString(),
                                        reader["NombreCiudad"].ToString(), pais);

                    ciudades.Add(ciudad);
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
            return ciudades;
        }
        public void Registrar(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_RegistrarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("CodigoCiudad", ciudad.CodigoCiudad));
            command.Parameters.Add(new SqlParameter("Nombre", ciudad.NombreCiudad));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ya existe una ciudad registrada con los códigos ingresados.");

                else if (retorno == -2)
                    throw new Exception("Ningún país en el sistema con el código ingresado.");

                else if (retorno == -3)
                    throw new Exception("Error al registrar ciudad.");
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
        public void Eliminar(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EliminarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("CodigoCiudad", ciudad.CodigoCiudad));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ninguna ciudad en el sistema con el código ingresado.");

                else if (retorno == 2)
                    throw new Exception("No se pudo eliminar ciudad.");
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
        public void Modificar(Ciudad ciudad)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EditarCiudad", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("codPais", ciudad.Pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("codCiudad", ciudad.CodigoCiudad));
            command.Parameters.Add(new SqlParameter("nomCiudad", ciudad.NombreCiudad));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ninguna ciudad con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("Error al modificar ciudad.");
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
        public List<Ciudad> CiudadesdePais(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_CiudadesdePais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", pais.CodigoPais));

            SqlDataReader reader;
            List<Ciudad> ciudades = new List<Ciudad>();

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {                    
                    Ciudad ciudad = new Ciudad(reader["CodigoCiudad"].ToString(),
                                        reader["NombreCiudad"].ToString(), pais);

                    ciudades.Add(ciudad);
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
            return ciudades;
        }
    }
}
