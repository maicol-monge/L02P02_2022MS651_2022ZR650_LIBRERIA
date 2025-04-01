using System.ComponentModel.DataAnnotations;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class Categorias
    {
        [Key]
        public int id { get; set; }
        public string nombreCategoria { get; set; }
    }
}
