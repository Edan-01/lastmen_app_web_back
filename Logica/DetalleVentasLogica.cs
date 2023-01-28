using Logica.Interface;
using Modelos;
using Repositorio;

namespace Logica
{
    public class DetalleVentasLogica : ICRUDLogica<DetalleVentaModel>
    {
    
        DetalleVentasRepositorio repo = new DetalleVentasRepositorio();

        public DetalleVentaModel ActualizarRegistro(DetalleVentaModel input)
        {
            input = repo.ActualizarRegistro(input);
            return input;
        }

        public DetalleVentaModel CrearRegistro(DetalleVentaModel input)
        {
            input = repo.CrearRegistro(input);
            return input;
        }

        public int deleteRegistro(int id)
        {
            id = repo.deleteRegistro(id);
            return id;
        }

        public List<DetalleVentaModel> ListarTodo()
        {
            List<DetalleVentaModel> lista = repo.ListarTodo();
            return lista;
        }

        public DetalleVentaModel ObtenerPorId(int id)
        {
            DetalleVentaModel resultado = repo.ObtenerPorId(id);
            return resultado;
        }
    }
}
