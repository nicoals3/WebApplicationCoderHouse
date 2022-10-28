using System.Data;
using System.Data.SqlClient;
using WebApplicationCoderHouse.Models;

namespace WebApplicationCoderHouse.Repository
{
    public class ADO_Usuario
    {
        public static Usuario DevolverUsuario(string nombreUsuario)
        {
            var UsuarioDevuelto = new Usuario();

            var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario WHERE NombreUsuario = @NombreUsuario";

            SqlConnectionStringBuilder connecctionbuilder = new();
            connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
            connecctionbuilder.InitialCatalog = "SistemaGestion";
            connecctionbuilder.IntegratedSecurity = true;
            var cs = connecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "NombreUsuario";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contraseña = dr["Contraseña"].ToString();
                                usuario.Mail = dr["Mail"].ToString();

                                UsuarioDevuelto = usuario;
                            }
                            dr.Close();
                        }

                    }
                    connection.Close();
                }
            }
            return UsuarioDevuelto;
        }

        public static long CrearUsuario(Usuario usu)

        {
            long id;
            SqlConnectionStringBuilder connecctionbuilder = new();
            connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
            connecctionbuilder.InitialCatalog = "SistemaGestion";
            connecctionbuilder.IntegratedSecurity = true;
            var cs = connecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail); Select scope_identity()", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = usu.Nombre;
                cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = usu.Apellido;
                cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = usu.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = usu.Contraseña;
                cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = usu.Mail;
                id = Convert.ToInt64(cmd.ExecuteScalar());
                connection.Close();
            }
            return id;

        }
        public static int ModificarUsuario(Usuario usu)

        {
            int filas_modificadas;
            SqlConnectionStringBuilder connecctionbuilder = new();
            connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
            connecctionbuilder.InitialCatalog = "SistemaGestion";
            connecctionbuilder.IntegratedSecurity = true;
            var cs = connecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Usuario SET  Nombre = @Nombre, Apellido = @Apellido , NombreUsuario = @NombreUsuario , Contraseña = @Contraseña , Mail = @Mail WHERE id = @id", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.NVarChar)).Value = usu.Id;
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = usu.Nombre;
                cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = usu.Apellido;
                cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = usu.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = usu.Contraseña;
                cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = usu.Mail;
                filas_modificadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
            }
            return filas_modificadas;
        }
        public static int EliminarUsuario(long idUsuario)

        {
            int filas_eliminadas;
            SqlConnectionStringBuilder connecctionbuilder = new();
            connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
            connecctionbuilder.InitialCatalog = "SistemaGestion";
            connecctionbuilder.IntegratedSecurity = true;
            var cs = connecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Delete FROM Usuario WHERE Id = @IdUsuario", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt)).Value = idUsuario;
                filas_eliminadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
            }
            return filas_eliminadas;
        }
    }
}
