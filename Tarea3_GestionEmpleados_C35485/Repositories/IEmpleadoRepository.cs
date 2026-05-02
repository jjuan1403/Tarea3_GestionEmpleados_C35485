using Tarea3_GestionEmpleados_C35485.Models;

namespace Tarea3_GestionEmpleados_C35485.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ObtenerTodos();
        Empleado? ObtenerPorId(int id);
        List<Empleado> BuscarPorNombreODepartamento(string termino);
        List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda);
        int ContarTotal(string? busqueda);
        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
        void ToggleActivo(int id);
    }
}