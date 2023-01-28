using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;
using Repositorio.Interface;

namespace Repositorio
{
    public class VentasRepositorio : ICRUD<VentasModel>
    {
         _dbContext db = new _dbContext();
        public VentasModel ActualizarRegistro(VentasModel input)
        {
            db.Ventas.Update(input);
            db.SaveChanges();
            return input;
        }

        public VentasModel CrearRegistro(VentasModel input)
        {
            db.Ventas.Add(input);
                db.SaveChanges();
            return input;
        }

        public int deleteRegistro(int id)
        {

            VentasModel ventas = db.Ventas.Find(id);
            db.Ventas.Remove(ventas);
            return db.SaveChanges();
        }

        public List<VentasModel> ListarTodo()
        {
            List<VentasModel> lista = db.Ventas.ToList();
            return lista;
        }

        public VentasModel ObtenerPorId(int id)
        {
            VentasModel ventas = db.Ventas.Find(id);
            return ventas;
        }
        //public List<VentasModel> ListarTodoDetallado()
        //{
        //    List<VentasModel> lista =
        //        db.Ventas
        //        .Include(x => x.DetalleVentas)
       
        //        .ToList();

        //    return lista;
        //}
    }
}
