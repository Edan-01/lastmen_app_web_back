using Modelos;
using Repositorio.Interface;
using Utilitarios;

namespace Repositorio
{
    public class UsuarioRepositorio : ICRUD<UsuarioModel>
    {
        _dbContext db = new _dbContext();
        public UsuarioModel ActualizarRegistro(UsuarioModel input)
        {
            input.Password = UtilSecurity.encriptar_AES(input.Password);
            db.Usuario.Update(input);
            db.SaveChanges();
            return input;
        }

        public UsuarioModel CrearRegistro(UsuarioModel input)
        {
            input.Password = UtilSecurity.encriptar_AES(input.Password);
            db.Usuario.Add(input);
            db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            UsuarioModel usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            return db.SaveChanges();
        }

        public List<UsuarioModel> ListarTodo()
        {
            List<UsuarioModel> lista = db.Usuario.ToList();
            return lista;
        }

        public UsuarioModel ObtenerPorId(int id)
        {
            UsuarioModel usuario = db.Usuario.Find(id);
            return usuario;
        }

        public UsuarioModel ObtenerUsuarioPorUserrName(string username)
        {
            // sintaxis lambda
            UsuarioModel user = db.Usuario.Where(x => x.Usuario == username).FirstOrDefault();
            return user;
        }
    }
}
