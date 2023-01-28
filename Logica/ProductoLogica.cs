using Logica.Interface;
using Modelos;
using Repositorio;

namespace Logica
{

    public class ProductoLogica : ICRUDLogica<ProductoModel>
    {
     
        ProductoRepositorio repo = new ProductoRepositorio();
        

        public ProductoModel ActualizarRegistro(ProductoModel input)
        {
            input = repo.ActualizarRegistro(input);
            return input;
        }

        public ProductoModel CrearRegistro(ProductoModel input)
        {
            input = repo.CrearRegistro(input);
            return input;
        }

        public int deleteRegistro(int id)
        {
            id = repo.deleteRegistro(id);
            return id;
        }

        public List<ProductoModel> ListarTodo()
        {
            List<ProductoModel> lista = repo.ListarTodo();
            return lista;
        }

        public ProductoModel ObtenerPorId(int id)
        {
            ProductoModel resultado = repo.ObtenerPorId(id);
            return resultado;
        }

        public bool updateMultipleRegistro (List<ProductoModel> lst)
        {
            repo.updateMultipleRegistro(lst);
            return true; 
        }

        public async Task<bool> AddImageAsync(int id, string path)
        {
           repo.AddImageAsync(id, path);

            // operador ternario
            return  true;
        }
    }
}
