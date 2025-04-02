using L02P02_2022MS651_2022ZR650.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

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
        public static int GetNextId(libreriaDbContext context)
        {
            var lastId = context.comentarios_libros.Max(p => (int?)p.id) ?? 0;
            return lastId + 1;
        }
        public IActionResult ComentariosLibros(int idLibro, string nombreLibro, string nombreAutor, bool? ComentarioAgregado, string? Comentario)
        {
            ViewBag.nombreLibro = nombreLibro;
            ViewBag.nombreAutor = nombreAutor;
            ViewBag.idLibro = idLibro;
            ViewBag.ComentarioAgregado = ComentarioAgregado;
            ViewBag.Comentario = Comentario;

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
                    id = ComentariosController.GetNextId(_context),
                    id_libro = idLibro,
                    comentarios = comentario,
                    usuario = "Chepe5000", 
                    created_at = DateTime.Now
                };

                _context.comentarios_libros.Add(nuevoComentario);
                _context.SaveChanges();

                ViewBag.ComentarioAgregado = true;
                ViewBag.Comentario = nuevoComentario.comentarios;
                ViewBag.nombreAutor = Request.Form["nombreAutor"]; 
                ViewBag.nombreLibro = Request.Form["nombreLibro"];
            }
            else
            {
                ViewBag.ComentarioAgregado = false;
            }

            return RedirectToAction("ComentariosLibros", new { idLibro = idLibro, nombreLibro = ViewBag.nombreLibro, nombreAutor = ViewBag.nombreAutor, ComentarioAgregado = ViewBag.ComentarioAgregado, Comentario = ViewBag.Comentario });
        }

    }
}
