using GreenFlamingos.Model;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase.EntityFramework
{
    public class GreenFlamingosDbContext : DbContext
    {
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<MainIngredinet> MainIngredients { get; set; }

        public GreenFlamingosDbContext(DbContextOptions options) : base(options) {}
    }
}