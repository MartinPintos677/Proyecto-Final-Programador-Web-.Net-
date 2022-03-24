using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    public class PerPais
    {
        public Pais Buscar(string codigoPais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_BuscarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", codigoPais));

            SqlDataReader reader;
            Pais pais = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pais = new Pais(reader["CodigoPais"].ToString(),
                                    reader["NombrePais"].ToString());
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
            return pais;
        }
        public void Registrar(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_RegistrarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("Nombre", pais.NombrePais));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ya existe un país registrado con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("Ya existe un país con el nombre ingresado.");

                else if (retorno == -3)
                    throw new Exception("No se pudo registrar país.");
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
        public void Eliminar(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EliminarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("CodigoPais", pais.CodigoPais));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ningún país en el sistema con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("No se puede eliminar país con pronósticos asociados.");

                else if (retorno == 3)
                    throw new Exception("No se pudo eliminar el país.");
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
        public void Modificar(Pais pais)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EditarPais", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("codPais", pais.CodigoPais));
            command.Parameters.Add(new SqlParameter("nomPais", pais.NombrePais));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ningún país con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("Error al modificar país.");
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
        public List<Pais> Todos()
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_TodoslosPaises", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader;
            List<Pais> paises = new List<Pais>();

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pais pais = new Pais(reader["CodigoPais"].ToString(),
                                         reader["NombrePais"].ToString());

                    paises.Add(pais);
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
            return paises;
        }
    }
}
