using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Xml.Linq;
using WebApplicationCoderHouse.Models;

namespace WebApplicationCoderHouse.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> DevolverProductoVendido(int IdUsuario)
        {
            var listaProductoVendido = new List<ProductoVendido>();

            var query = "SELECT P.Id, Descripciones, PV.Stock, IdVenta FROM Producto AS P INNER JOIN ProductoVendido AS PV ON P.Id = PV.IdProducto WHERE IdUsuario = @IdUsuario ";

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
                    parametro.Value = IdUsuario;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var ProductoVendido = new ProductoVendido();
                                ProductoVendido.Id = Convert.ToInt32(dr["Id"]);
                                ProductoVendido.Descripciones = dr["Descripciones"].ToString();
                                ProductoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                ProductoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);

                                listaProductoVendido.Add(ProductoVendido);
                            }
                            dr.Close();
                        }
                    }
                }

            }
            return listaProductoVendido;


        }
        
    }
}
