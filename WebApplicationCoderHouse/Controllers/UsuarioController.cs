using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoderHouse.Models;
using WebApplicationCoderHouse.Repository;

namespace WebApplicationCoderHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet(Name = "GetUsuario")]
        public Usuario Get(String usu)
        {
            return ADO_Usuario.DevolverUsuario(usu);
        }
        [HttpPost]
        public long Crear([FromBody] Usuario usu)
        {
            return ADO_Usuario.CrearUsuario(usu);
        }

        [HttpPut]
        public long Actualizar([FromBody] Usuario usu)
        {
            return ADO_Usuario.ModificarUsuario(usu);
        }

        [HttpDelete]
        public long Eliminar([FromBody] long idUsuario)
        {
            return ADO_Usuario.EliminarUsuario(idUsuario);
        }

    }
}
