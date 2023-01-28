using Modelos;
using Repositorio.Interface;

namespace Repositorio
{
    public class ClienteRepositorio : ICRUD<ClienteModel>
    {
        _dbContext db = new _dbContext();

        public ClienteModel ActualizarRegistro(ClienteModel input)
        {
            db.Clientes.Update(input);
            db.SaveChanges();
            return input;
        }

        public ClienteModel CrearRegistro(ClienteModel input)
        {
            db.Clientes.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            ClienteModel cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            return db.SaveChanges();
        }

        public List<ClienteModel> ListarTodo()
        {
            List<ClienteModel> lista = db.Clientes.ToList();
            return lista;
        }

        public ClienteModel ObtenerPorId(int id)
        {
            ClienteModel cliente = db.Clientes.Find(id);
            return cliente;
        }

    }
}
