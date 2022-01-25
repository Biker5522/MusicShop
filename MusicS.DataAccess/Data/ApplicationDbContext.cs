using Microsoft.EntityFrameworkCore;
using MusicS.Models;

namespace MusicS.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
