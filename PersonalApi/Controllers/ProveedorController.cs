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
   
    public class ProveedorController : ControllerBase
    {
        /*ctrl + r + r */
        ProveedorLogica proveedorlog = new ProveedorLogica();

        [HttpGet]
        public IActionResult get()
        {
            List<ProveedorModel> listaResultado = new List<ProveedorModel>();
            listaResultado = proveedorlog.ListarTodo();
            return Ok(listaResultado);
        }


        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            ProveedorModel res = new ProveedorModel();
            res = proveedorlog.ObtenerPorId(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post(ProveedorModel request)
        {
            ProveedorModel response = proveedorlog.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult put(ProveedorModel request)
        {
            ProveedorModel response = proveedorlog.ActualizarRegistro(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int response = proveedorlog.deleteRegistro(id);
            return Ok(response);
        }

    }
}
