using System.Data.SqlClient;
using WebApplicationCoderHouse.Models;

namespace WebApplicationCoderHouse.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> DevolverVenta(int idUsuario)
        {
            var listaVenta = new List<Venta>();

            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE idUsuario = @idUsuario ";

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

                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idUsuario;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var Venta = new Venta();
                                Venta.Id = Convert.ToInt32(dr["Id"]);
                                Venta.Comentarios = dr["Comentarios"].ToString();
                                Venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                listaVenta.Add(Venta);
                            }
                            dr.Close();
                        }
                    }
                }

            }
            return listaVenta;


        }
    }
}
