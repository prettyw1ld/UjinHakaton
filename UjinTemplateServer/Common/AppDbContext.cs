using Microsoft.EntityFrameworkCore;
using UjinTemplateServer.Models;

namespace UjinTemplateServer.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<Template> Templates { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Complex> Complexes { get; set; }
    }
}
