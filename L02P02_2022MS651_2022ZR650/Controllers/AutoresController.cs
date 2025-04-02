using L02P02_2022MS651_2022ZR650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022MS651_2022ZR650.Controllers
{
    public class AutoresController : Controller
    {
        private readonly libreriaDbContext _context;

        public AutoresController(libreriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var autores = _context.autores.ToList();
            return View(autores);
        }

        public IActionResult Libros(int id)
        {
            
            return RedirectToAction("VerLibros", "Libros", new { autorId = id });
        }
    }
}
