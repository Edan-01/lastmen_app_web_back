using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class VentasModel
    {
        [Key] // es la llave primaria de mi base de dato
        public int IdVenta { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdCliente { get; set; }

        public string Fecha { get; set; }

        public string TipoComprobante { get; set; }
        public virtual List<DetalleVentaModel> DetalleVentas { get; set; }
    }
}
