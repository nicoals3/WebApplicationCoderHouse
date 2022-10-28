using System.Data.SqlClient;
using WebApplicationCoderHouse.Models;

namespace WebApplicationCoderHouse.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> DevolverProducto(int idUsuario)
        {

            var listaProductos = new List<Producto>();

            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE IdUsuario = @IdUsuario ";

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

                    parametro.ParameterName = "IdUsuario";
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
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripciones = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt32(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                listaProductos.Add(producto);
                            }
                            dr.Close();
                        }
                    }
                }
            }
            return listaProductos;


        }
    }
}
