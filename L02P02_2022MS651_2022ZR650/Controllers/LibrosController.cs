using L02P02_2022MS651_2022ZR650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022MS651_2022ZR650.Controllers
{
    public class LibrosController : Controller
    {
        private readonly libreriaDbContext _context;

        public LibrosController(libreriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerLibros(int idAutor)
        {
            idAutor = 1; // Solo para pruebas


            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);
            if (autor == null)
            {
                TempData["Error"] = "Autor no encontrado.";
                return RedirectToAction("Index");
            }

            ViewBag.NombreAutor = autor.autor;


            var libros = _context.libros
                .Where(l => l.id_autor == idAutor)
                .ToList();

            if (libros == null || !libros.Any())
            {
                TempData["Error"] = "No hay libros disponibles para este autor.";
                return RedirectToAction("/Views/Libros/Libros.cshtml"); // O redirigir a otra vista
            }
            return View("/Views/Libros/Libros.cshtml", libros);
        }


    }
}
