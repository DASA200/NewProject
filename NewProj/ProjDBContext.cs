using DBOPERATION.Domain;
using Microsoft.EntityFrameworkCore;

namespace NewProj
{
    public class ProjDBContext : DbContext
    {
        public ProjDBContext(DbContextOptions<ProjDBContext> options):base(options) 
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
