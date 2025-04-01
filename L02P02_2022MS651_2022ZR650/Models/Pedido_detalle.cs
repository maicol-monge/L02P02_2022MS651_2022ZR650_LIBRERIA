using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class Pedido_detalle
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_pedido { get; set; }
        [Required]
        public int id_libro { get; set; }
        public DateTime created_at { get; set; }
    }
}
