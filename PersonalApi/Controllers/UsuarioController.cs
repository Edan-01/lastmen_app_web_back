using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace PersonalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        UsuarioLogica usuariologica = new UsuarioLogica();

        [HttpGet]
        public IActionResult get()
        {
            List<UsuarioModel> listaResultado = new List<UsuarioModel>();
            listaResultado = usuariologica.ListarTodo();
            return Ok(listaResultado);
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            UsuarioModel res = new UsuarioModel();
            res = usuariologica.ObtenerPorId(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post(UsuarioModel request)
        {
            UsuarioModel response = usuariologica.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult put(UsuarioModel request)
        {
            UsuarioModel response = usuariologica.ActualizarRegistro(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int response = usuariologica.deleteRegistro(id);
            return Ok(response);
        }
    }
}
