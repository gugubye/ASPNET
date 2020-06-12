using Microsoft.EntityFrameworkCore;
using AspEFCore.Domain;

namespace AspEFCore.Data
{
    public class Mycontext : DbContext
    {

        public Mycontext(DbContextOptions<Mycontext> options):base(options)
        {

        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
