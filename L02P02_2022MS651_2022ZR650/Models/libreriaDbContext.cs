using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MS651_2022ZR650.Models
{
    public class libreriaDbContext : DbContext
    {

        libreriaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
