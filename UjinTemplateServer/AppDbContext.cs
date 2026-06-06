using Microsoft.EntityFrameworkCore;

namespace UjinTemplateServer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<Templates> Templates { get; set; }
        public DbSet<TemplateScreens> TemplateScreens { get; set; }
        public DbSet<Screen> Screens { get; set; }
    }
}
