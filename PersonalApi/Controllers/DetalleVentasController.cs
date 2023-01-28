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
    public class DetalleVentasController : ControllerBase
    {
        DetalleVentasLogica detalleventa = new DetalleVentasLogica();

        [HttpGet]
        public IActionResult get()
        {
            List<DetalleVentaModel> listaResultado = new List<DetalleVentaModel>();
            listaResultado = detalleventa.ListarTodo();
            return Ok(listaResultado);
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            DetalleVentaModel res = new DetalleVentaModel();
            res = detalleventa.ObtenerPorId(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post(DetalleVentaModel request)
        {
            DetalleVentaModel response = detalleventa.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult put(DetalleVentaModel request)
        {
            DetalleVentaModel response = detalleventa.ActualizarRegistro(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int response = detalleventa.deleteRegistro(id);
            return Ok(response);
        }
    }
}
