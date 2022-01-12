using Microsoft.EntityFrameworkCore;

namespace MusicShop.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Album> Albums { get; set; }
    }
}
