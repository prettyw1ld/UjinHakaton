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
    }
}
