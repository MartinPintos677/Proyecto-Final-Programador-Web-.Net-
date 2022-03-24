using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    public class PerUsuario
    {
        public Usuario Buscar(string codigo)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_BuscarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("logueoUsuario", codigo));

            SqlDataReader reader;
            Usuario usuario = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario(reader["LogueoUsuario"].ToString(), reader["Contrasena"].ToString(),
                        reader["Nombre"].ToString(), reader["Apellido"].ToString());
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
            return usuario;
        }

        public Usuario Login(string logueo, string password)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_logueousuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("logueo", logueo));
            command.Parameters.Add(new SqlParameter("contrasena", password));

            SqlDataReader reader;
            Usuario usuario = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario(reader["LogueoUsuario"].ToString(), reader["Contrasena"].ToString(),
                        reader["Nombre"].ToString(), reader["Apellido"].ToString());
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
            return usuario;
        }

        public void Registrar(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);

            SqlCommand command = new SqlCommand("sp_RegistrarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("loginUsuario", usuario.LogueoUsuario));
            command.Parameters.Add(new SqlParameter("contrasena", usuario.Contrasena));
            command.Parameters.Add(new SqlParameter("nombre", usuario.Nombre));
            command.Parameters.Add(new SqlParameter("apellido", usuario.Apellido));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("Ya existe usuario con el código ingresado.");

                else if (retorno == -2)
                    throw new Exception("Error al registrar usuario.");
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

        public void Eliminar(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EliminarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("loginUsuario", usuario.LogueoUsuario));
            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    throw new Exception("No se puede eliminar usuario con pronóstico asociado.");

                else if (retorno == -2)
                    throw new Exception("No existe usuario con el código ingresado.");

                else if (retorno == -3)
                    throw new Exception("Error desconocido.");
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

        public void Modificar(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EditarUsuario", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("loginUsuario", usuario.LogueoUsuario));
            command.Parameters.Add(new SqlParameter("contrasena", usuario.Contrasena));
            command.Parameters.Add(new SqlParameter("nombre", usuario.Nombre));
            command.Parameters.Add(new SqlParameter("apellido", usuario.Apellido));

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
                    throw new Exception("Error al registrar usuario.");
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
        public bool BuscarbtnEliminar(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Conexion.connectionString);
            SqlCommand command = new SqlCommand("sp_EliminarUsuariobtn", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("loginUsuario", usuario.LogueoUsuario));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(r);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                int retorno = Convert.ToInt32(r.Value);

                if (retorno == -1)
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
