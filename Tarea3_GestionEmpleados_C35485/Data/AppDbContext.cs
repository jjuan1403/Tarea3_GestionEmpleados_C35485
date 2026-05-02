using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C35485.Models;

namespace Tarea3_GestionEmpleados_C35485.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasPrecision(10, 2);
        }
    }
}
