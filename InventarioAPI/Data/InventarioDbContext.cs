using Microsoft.EntityFrameworkCore;
using InventarioAPI.Models; // Verifica que esta carpeta exista y tenga los archivos

namespace InventarioAPI.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<DetalleCpu> DetallesCpu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // <-- CORREGIDO AQUÍ
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuramos la relación 1 a 1
            modelBuilder.Entity<DetalleCpu>()
                .HasKey(d => d.EquipoId);
        }
    }
}