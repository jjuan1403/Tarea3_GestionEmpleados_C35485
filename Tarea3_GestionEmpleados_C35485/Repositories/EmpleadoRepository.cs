using Tarea3_GestionEmpleados_C35485.Data;
using Tarea3_GestionEmpleados_C35485.Models;

namespace Tarea3_GestionEmpleados_C35485.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public List<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            return AplicarFiltro(termino).ToList();
        }

        public List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            return AplicarFiltro(busqueda)
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            return AplicarFiltro(busqueda).Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = ObtenerPorId(id);

            if (empleado == null)
                return;

            empleado.Activo = !empleado.Activo;
            _context.SaveChanges();
        }

        private IQueryable<Empleado> AplicarFiltro(string? busqueda)
        {
            var empleados = _context.Empleados.AsQueryable();

            if (string.IsNullOrWhiteSpace(busqueda))
                return empleados;

            busqueda = busqueda.ToLower();

            return empleados.Where(e =>
                e.Nombre.ToLower().Contains(busqueda) ||
                e.Apellidos.ToLower().Contains(busqueda) ||
                e.Departamento.ToLower().Contains(busqueda));
        }
    }
}