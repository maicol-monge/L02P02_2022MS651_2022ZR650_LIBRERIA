using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class libreriaDbContext : DbContext
    {

        public libreriaDbContext(DbContextOptions<libreriaDbContext> options) : base(options)
        {

        }
    }
}
