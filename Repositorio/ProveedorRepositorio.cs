using Modelos;
using Repositorio.Interface;

namespace Repositorio
{
    public class ProveedorRepositorio : ICRUD<ProveedorModel>
    {
        _dbContext db = new _dbContext();

        public ProveedorModel ActualizarRegistro(ProveedorModel input)
        {
            db.Proveedor.Update(input);
            db.SaveChanges();
            return input;
        }

        public ProveedorModel CrearRegistro(ProveedorModel input)
        {
            db.Proveedor.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            ProveedorModel proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
            return db.SaveChanges();
        }

        public List<ProveedorModel> ListarTodo()
        {
            List<ProveedorModel> lista = db.Proveedor.ToList();
            return lista;
        }

        public ProveedorModel ObtenerPorId(int id)
        {
            ProveedorModel proveedor = db.Proveedor.Find(id);
            return proveedor;
        }

    }
}
