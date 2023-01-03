using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase
{
    public class GreenFlamingosDbContext : DbContext
    {
        public DbSet<DbDrink> DbDrinks { get; set; }
        public DbSet<DbMainIngredient> DbMainIngredients { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbPreparation> MyProperty { get; set; }

        public GreenFlamingosDbContext(DbContextOptions options) : base(options) {}
    }
}
