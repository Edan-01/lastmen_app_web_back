using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    
    public class UsuarioModel
    {
        [Key] // es la llave primaria de mi base de datos
      
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
  
    }
}
