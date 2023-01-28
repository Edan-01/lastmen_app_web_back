using Logica.Interface;
using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProveedorLogica : ICRUDLogica<ProveedorModel>
    {
        ProveedorRepositorio repo = new ProveedorRepositorio();
        public ProveedorModel ActualizarRegistro(ProveedorModel input)
        {
            input = repo.ActualizarRegistro(input);
            return input;
        }

        public ProveedorModel CrearRegistro(ProveedorModel input)
        {
            input = repo.CrearRegistro(input);
            return input;
        }

        public int deleteRegistro(int id)
        {
            id = repo.deleteRegistro(id);
            return id;
        }

        public List<ProveedorModel> ListarTodo()
        {
            List<ProveedorModel> lista = repo.ListarTodo();
            return lista;
        }

        public ProveedorModel ObtenerPorId(int id)
        {
            ProveedorModel resultado = repo.ObtenerPorId(id);
            return resultado;
        }
    }
}
