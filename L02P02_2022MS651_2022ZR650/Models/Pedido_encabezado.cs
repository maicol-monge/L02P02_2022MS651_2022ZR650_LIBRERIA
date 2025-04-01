using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class Pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
    }
}
