using Modelos;
using Repositorio.Interface;

namespace Repositorio
{
    public class DetalleVentasRepositorio : ICRUD<DetalleVentaModel>
    {
        _dbContext db = new _dbContext();
        public DetalleVentaModel ActualizarRegistro(DetalleVentaModel input)
        {
            db.DetalleVenta.Update(input);
            db.SaveChanges();
            return input;
        }

        public DetalleVentaModel CrearRegistro(DetalleVentaModel input)
        {
            db.DetalleVenta.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            DetalleVentaModel producto = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(producto);
            return db.SaveChanges();
        }

        public List<DetalleVentaModel> ListarTodo()
        {
            List<DetalleVentaModel> lista = db.DetalleVenta.ToList();
            return lista;
        }

        public DetalleVentaModel ObtenerPorId(int id)
        {
            DetalleVentaModel producto = db.DetalleVenta.Find(id);
            return producto;
        }
    }

}
