using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplicationCoderHouse.Models;
using WebApplicationCoderHouse.Repository;

namespace WebApplicationCoderHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendido")]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.DevolverProductoVendido(1);
        }
    }
}
