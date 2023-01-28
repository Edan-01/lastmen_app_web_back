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
    public class VentasController : ControllerBase
    {
        VentasLogica ventasLogica = new VentasLogica();

        [HttpGet]
        public IActionResult get()
        {
            List<VentasModel> listaResultado = new List<VentasModel>();
            listaResultado = ventasLogica.ListarTodo();
            return Ok(listaResultado);
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            VentasModel res = new VentasModel();
            res = ventasLogica.ObtenerPorId(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post(VentasModel request)
        {
            VentasModel response = ventasLogica.CrearRegistro(request);
            return Ok(response);
        }


        [HttpPut]
        public IActionResult put(VentasModel request)
        {
            VentasModel response = ventasLogica.ActualizarRegistro(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int response = ventasLogica.deleteRegistro(id);
            return Ok(response);
        }
        //[HttpGet]
        //[Route("detallado")]
        //public IActionResult getDetallado()
        //{
        //    List<VentasModel> listaResultado = new List<VentasModel>();
        //    listaResultado = ventasLogica.ListarTodoDetallado();
        //    return Ok(listaResultado);
        //}
    }
}
