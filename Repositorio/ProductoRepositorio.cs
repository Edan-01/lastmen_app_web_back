using Modelos;
using Repositorio.Interface;

namespace Repositorio
{
    public  class ProductoRepositorio : ICRUD<ProductoModel>
    {
         _dbContext db = new _dbContext();
        //private readonly _dbContext _db;

        //public ProductoRepositorio(_dbContext db)
        //{
        //    _db = db;
        //}


        public ProductoModel ActualizarRegistro(ProductoModel input)
        {
            db.Producto.Update(input);
            db.SaveChanges();
            return input;
        }

        public ProductoModel CrearRegistro(ProductoModel input)
        {
            db.Producto.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            ProductoModel producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            return db.SaveChanges();
        }

        public List<ProductoModel> ListarTodo()
        {
            List<ProductoModel> lista = db.Producto.ToList();
            return lista;
        }

        public ProductoModel ObtenerPorId(int id)
        {
            ProductoModel producto = db.Producto.Find(id);
            return producto;
        }
        public bool updateMultipleRegistro(List<ProductoModel> lst)
        {
            db.Producto.UpdateRange(lst);
            db.SaveChanges();
            return true;
        }


        public async Task<bool> AddImageAsync(int id, string path)
        {
           ProductoModel? producto = await db.Producto.FindAsync(id);
            if (producto == null)
            {
                throw new Exception("No existe la marca");
            }
            producto.Url_Img = path;
            int res = await db.SaveChangesAsync();

            // operador ternario
            return (res > 0) ? true : false;
        }
    }
}
