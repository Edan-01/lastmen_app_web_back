using Logica.Interface;
using Modelos;
using Repositorio;

namespace Logica
{
    public class CategoriaLogica : ICRUDLogica<CategoriaModel>
    {
        CategoriaRepositorio repo = new CategoriaRepositorio();

        public CategoriaModel ActualizarRegistro(CategoriaModel input)
        {
            input = repo.ActualizarRegistro(input);
            return input;
        }

        public CategoriaModel CrearRegistro(CategoriaModel input)
        {
            input = repo.CrearRegistro(input);
            return input;
        }

        public int deleteRegistro(int id)
        {
            id = repo.deleteRegistro(id);
            return id;
        }

        public List<CategoriaModel> ListarTodo()
        {
            List<CategoriaModel> lista = repo.ListarTodo();
            return lista;
        }

        public CategoriaModel ObtenerPorId(int id)
        {
            CategoriaModel resultado = repo.ObtenerPorId(id);
            return resultado;
        }

    }
}
