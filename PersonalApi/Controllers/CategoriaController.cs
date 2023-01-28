using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace PersonalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriaController : ControllerBase
    {
        CategoriaLogica categorialogica = new CategoriaLogica();

        [HttpGet]
        public IActionResult get()
        {
            List<CategoriaModel> listaResultado = new List<CategoriaModel>();
            listaResultado = categorialogica.ListarTodo();
            return Ok(listaResultado);
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            CategoriaModel res = new CategoriaModel();
            res = categorialogica.ObtenerPorId(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post(CategoriaModel request)
        {
            CategoriaModel response = categorialogica.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult put(CategoriaModel request)
        {
            CategoriaModel response = categorialogica.ActualizarRegistro(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int response = categorialogica.deleteRegistro(id);
            return Ok(response);
        }
    }
}
