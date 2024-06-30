using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SongContext(DbContextOptions<SongContext> options) : DbContext(options)
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongImage> SongImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
