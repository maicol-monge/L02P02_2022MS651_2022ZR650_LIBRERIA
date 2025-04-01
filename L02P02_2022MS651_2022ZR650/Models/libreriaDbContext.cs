using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class libreriaDbContext : DbContext
    {

        libreriaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Autores> autores { get; set; }
        public DbSet<Libros> libros { get; set; }
        public DbSet<Pedido_encabezado> pedido_encabezado { get; set; }
        public DbSet<Pedido_detalle> pedido_detalle { get; set; }
        public DbSet<Comentarios_libros> comentarios_libros { get; set; }

    }
}
