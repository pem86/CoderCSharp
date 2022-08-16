using PrimeraEntregaProyectoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntregaProyectoFinal.ADO.NET
{
    public class UsuarioHandler : DbHandler
    {
        public Usuario TraerUsuario(string nombreUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario;";
                    sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Usuario usuario = new Usuario();

                                    usuario.id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.nombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.nombre = dataReader["Nombre"].ToString();
                                    usuario.apellido = dataReader["Apellido"].ToString();
                                    usuario.contrasenia = dataReader["Contraseña"].ToString();
                                    usuario.mail = dataReader["Mail"].ToString();

                                    usuarios.Add(usuario);
                                }
                            }
                        }

                        sqlConnection.Close();
                    }
                }

                return usuarios.First();
            }
        }

        public Usuario IniciarSesion(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText =
                            "SELECT * FROM Usuario " +
                            "WHERE NombreUsuario = @nombreUsuario " +
                            "AND Contraseña = @contrasenia;";
                    sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    sqlCommand.Parameters.AddWithValue("@contrasenia", contrasenia);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            
                            usuario.id = Convert.ToInt32(dataReader["Id"]);
                            usuario.nombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.nombre = dataReader["Nombre"].ToString();
                            usuario.apellido = dataReader["Apellido"].ToString();
                            usuario.contrasenia = dataReader["Contraseña"].ToString();
                            usuario.mail = dataReader["Mail"].ToString();
                        }
                        else
                        {
                            usuario.id = 0;
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return usuario;
        }
    }
}
