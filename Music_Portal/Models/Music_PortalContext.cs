using Microsoft.EntityFrameworkCore;

namespace Music_Portal.Models
{
    public class Music_PortalContext : DbContext
    {
        public Music_PortalContext(DbContextOptions<Music_PortalContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
