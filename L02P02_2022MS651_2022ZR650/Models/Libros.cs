using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class Libros
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string url_imagen { get; set; }
        [Required]
        public int id_autor { get; set; }
        [Required]
        public int id_categoria { get; set; }
        public decimal precio { get; set; }
        public char estado { get; set; }

    }
}
