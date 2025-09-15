using Microsoft.EntityFrameworkCore;
using Presenter.Models;

namespace Presenter.Services
{
    public class SongContext(DbContextOptions<SongContext> options) : DbContext(options)
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongImage> SongImages { get; set; }
    }
}
