using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ProductoModel    {
        [Key] // es la llave primaria de mi base de dato
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProducto { get; set; }

        public string? Descripcion { get; set; }

        public string Unidad_Medida { get; set; }

        public decimal Cantidad { get; set; }

        public string FechaVencimiento { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        public string Lote { get; set; }

        public string FechaIngreso { get; set; }

        public string? Url_Img { get; set; }

    }
}
