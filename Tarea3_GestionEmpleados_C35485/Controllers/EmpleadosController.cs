using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C35485.Models;
using Tarea3_GestionEmpleados_C35485.Repositories;

namespace Tarea3_GestionEmpleados_C35485.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            int tamanoPagina = 5;

            var empleados = _repo.ObtenerPaginado(pagina, tamanoPagina, busqueda);
            var total = _repo.ContarTotal(busqueda);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanoPagina);
            ViewBag.Busqueda = busqueda;
            ViewBag.TotalRegistros = total;

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            empleado.Activo = true;
            empleado.FechaIngreso = DateTime.Now;

            _repo.Agregar(empleado);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado == null)
                return NotFound();

            return View(empleado);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            _repo.Actualizar(empleado);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}