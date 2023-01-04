using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase
{
    public class GreenFlamingosDbContext : DbContext
    {
        public DbSet<DbDrink> DbDrinks { get; set; }
        public DbSet<DbMainIngredient> DbMainIngredients { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbDrinkType> DrinkTypes { get; set; }
        public DbSet<DbUserDetails> UsersDetails { get; set; }
        public DbSet<DbIngredient> Ingredients { get; set; }


        public GreenFlamingosDbContext(DbContextOptions options) : base(options) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relation one to one
            modelBuilder.Entity<DbUser>()
                .HasOne(u => u.UserDetails)
                .WithOne(ud => ud.User)
                .HasForeignKey<DbUserDetails>(ud => ud.UserId);

            //Relations one to many
            modelBuilder.Entity<DbDrink>()
                .HasOne(d => d.MainIngredient)
                .WithMany()
                .HasForeignKey(d => d.MainIngredientId);
            modelBuilder.Entity<DbDrink>()
                .HasOne(d => d.DrinkType)
                .WithMany()
                .HasForeignKey(d => d.DrinkTypeId);

            //Relations many to many drinks < - > ingredients
            modelBuilder.Entity<DbDrinkIngredient>()
                .HasKey(x => new { x.DrinkId, x.IngredientId });

            modelBuilder.Entity<DbDrinkIngredient>()
                .HasOne(x => x.Drink)
                .WithMany(x => x.DrinkIngredients)
                .HasForeignKey(x => x.DrinkId);
            modelBuilder.Entity<DbDrinkIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(x => x.DrinkIngredients)
                .HasForeignKey(x => x.IngredientId);

        }
    }
}
