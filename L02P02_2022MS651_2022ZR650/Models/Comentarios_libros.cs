using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class Comentarios_libros
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_libro { get; set; }
        public string comentarios { get; set; }
        public string usuario { get; set; }
        public DateTime created_at { get; set; }
    }
}
