using Microsoft.EntityFrameworkCore;
using Modelos;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repositorio
{
    public class CategoriaRepositorio : ICRUD<CategoriaModel>
    {
        _dbContext db = new _dbContext();

        public CategoriaModel ActualizarRegistro(CategoriaModel input)
        {
            db.Categoria.Update(input);
            db.SaveChanges();
            return input;
        }

        public CategoriaModel CrearRegistro(CategoriaModel input)
        {
            db.Categoria.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            CategoriaModel categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
            return db.SaveChanges();
        }

        public List<CategoriaModel> ListarTodo()
        {
            List<CategoriaModel> lista = db.Categoria.ToList();
            return lista;
        }

        public CategoriaModel ObtenerPorId(int id)
        {
            CategoriaModel categoria = db.Categoria.Find(id);
            return categoria;
        }
    }
}
