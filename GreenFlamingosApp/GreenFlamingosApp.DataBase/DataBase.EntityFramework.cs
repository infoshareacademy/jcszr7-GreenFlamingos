using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GreenFlamingosApp.DataBase
{
    public class GreenFlamingosDbContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<MainIngredinet> MainIngredients { get; set; }
        public GreenFlamingosDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Drink>()
                .HasOne(x => x.MainIngredient)
                .WithOne(x => x.Drink)
                .HasForeignKey<MainIngredinet>(x => x.DrinkId);
        }


    }

    
}
