using L02P02_2022MS651_2022ZR650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022MS651_2022ZR650.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly libreriaDbContext _context;

        public ComentariosController(libreriaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComentariosLibros(int idLibro, string nombreLibro, string nombreAutor)
        {
            ViewBag.NombreLibro = nombreLibro;
            ViewBag.NombreAutor = nombreAutor;
            ViewBag.IdLibro = idLibro;

            var comentarios = _context.comentarios_libros
                .Where(c => c.id_libro == idLibro)
                .OrderByDescending(c => c.created_at)
                .ToList();

            return View("ComentariosLibros", comentarios); 
        }

        [HttpPost]
        public IActionResult AgregarComentario(int idLibro, string comentario)
        {
            if (!string.IsNullOrEmpty(comentario))
            {
                var nuevoComentario = new Comentarios_libros
                {
                    id_libro = idLibro,
                    comentarios = comentario,
                    usuario = "Usuario Actual", // Reemplaza con el usuario actual
                    created_at = DateTime.Now
                };

                _context.comentarios_libros.Add(nuevoComentario);
                _context.SaveChanges();
            }

            return RedirectToAction("ComentariosLibros", new { idLibro = idLibro });
        }

    }
}
