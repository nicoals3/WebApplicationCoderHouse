using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoderHouse.Models;
using WebApplicationCoderHouse.Repository;

namespace WebApplicationCoderHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public List<Producto> Get()
        {
            return ADO_Producto.DevolverProducto(1);
        }
    }
}
