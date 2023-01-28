using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{

    public class CategoriaModel
    {
        [Key] // es la llave primaria de mi base de datos
      
        public int IdCategoria { get; set; }
        
        public string NombreCategoria { get; set; }  

    }
}