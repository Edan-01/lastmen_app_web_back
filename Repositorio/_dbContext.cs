using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class _dbContext:DbContext
    {
        #region configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            //    configurationBuild = configurationBuild.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            // Leemos el archivo de configuración.
            string conneccion = configurationFile.GetConnectionString("prueba_1");
            optionsBuilder.UseSqlServer(connectionString: conneccion);
        }
        #endregion

      

        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<ProductoModel> Producto { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<VentasModel> Ventas { get; set; }
        public DbSet<ProveedorModel> Proveedor { get; set; }
        public DbSet<ErrorModel> Error { get; set; }
        public DbSet<DetalleVentaModel>DetalleVenta{ get; set; }
        


    }
}
