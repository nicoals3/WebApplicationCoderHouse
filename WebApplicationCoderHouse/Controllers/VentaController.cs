using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoderHouse.Models;
using WebApplicationCoderHouse.Repository;

namespace WebApplicationCoderHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVenta")]
        public List<Venta> Get()
        {
            return ADO_Venta.DevolverVenta(1);
        }
    }
}
