using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleVentaModel
    {
        [Key] // es la llave primaria de mi base de datos
        public int IdDetalleCompra { get; set; }
        public int IdVenta { get; set; }
        [Required]
        public int IdProducto { get; set; } //id
        public string Nombre_producto { get; set; }                        //
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Precio_unitario { get; set; }
        public decimal Precio_total { get; set; }

        [JsonIgnore, ForeignKey("IdVenta")]
        public virtual VentasModel? Ventas { get; set; }
    }
}
