using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Interface;
using Modelos;
using Repositorio;


namespace Logica
{
    public class VentasLogica : ICRUDLogica<VentasModel>
    {
        VentasRepositorio repo = new VentasRepositorio();
        ProductoLogica productoLogica = new ProductoLogica();

        public VentasModel ActualizarRegistro(VentasModel input)
        {
            input = repo.ActualizarRegistro(input);
            return input;
        }

        public VentasModel CrearRegistro(VentasModel input)
        {
            input = repo.CrearRegistro(input);
            List<ProductoModel> lstProductosAfectados = new List<ProductoModel>();
            
            foreach (DetalleVentaModel item in input.DetalleVentas)
            {
                ProductoModel pt = productoLogica.ObtenerPorId(item.IdProducto);
                pt.Cantidad = pt.Cantidad - item.Cantidad;
                lstProductosAfectados.Add(pt);
            }
            productoLogica.updateMultipleRegistro(lstProductosAfectados);
            return input;
        }

        public int deleteRegistro(int id)
        {
            id = repo.deleteRegistro(id);
            return id;
        }

        public List<VentasModel> ListarTodo()
        {
            List<VentasModel> lista = repo.ListarTodo();
            return lista;
        }

        public VentasModel ObtenerPorId(int id)
        {
            VentasModel resultado = repo.ObtenerPorId(id);
            return resultado;
        }
        //public List<VentasModel> ListarTodoDetallado()
        //{
        //    List<VentasModel> lista = repo.ListarTodoDetallado();
        //    return lista;
        //}
    }
}
