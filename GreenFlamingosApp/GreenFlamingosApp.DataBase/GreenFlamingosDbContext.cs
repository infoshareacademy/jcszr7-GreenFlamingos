using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase
{
    public class GreenFlamingosDbContext : IdentityDbContext<DbUser>
    {
        public DbSet<DbDrink> DbDrinks { get; set; }
        public DbSet<DbMainIngredient> DbMainIngredients { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbDrinkType> DrinkTypes { get; set; }
        public DbSet<DbUserDetails> UsersDetails { get; set; }
        public DbSet<DbIngredient> Ingredients { get; set; }
        public DbSet<DbDrinkIngredient> DrinksIngredients { get; set; }
        public DbSet<DbDrinkUser> DrinkUsers { get; set; }
        public GreenFlamingosDbContext(DbContextOptions<GreenFlamingosDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .WithMany(x=>x.DrinkIngredients)
                .HasForeignKey(x => x.DrinkId);
            modelBuilder.Entity<DbDrinkIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(x=>x.DrinkIngredients)
                .HasForeignKey(x => x.IngredientId);

            //Relation many to many drinks < - > users
            modelBuilder.Entity<DbDrinkUser>()
                .HasKey(x => new { x.DrinkId, x.UserId });

            modelBuilder.Entity<DbDrinkUser>()
                .HasOne(x => x.Drink)
                .WithMany(x => x.DrinkUsers)
                .HasForeignKey(x => x.DrinkId);
            modelBuilder.Entity<DbDrinkUser>()
                 .HasOne(x => x.User)
                 .WithMany(x => x.DrinkUsers)
                 .HasForeignKey(x => x.UserId);

            // SEEDING
            modelBuilder.Entity<DbIngredient>()
                .HasData(new DbIngredient { Id = 1, Name = "Vodka" },
                         new DbIngredient { Id = 2, Name = "Rum" },
                         new DbIngredient { Id = 3, Name = "Whisky" },
                         new DbIngredient { Id = 4, Name = "Kostki lodu" },
                         new DbIngredient { Id = 5, Name = "Woda" },
                         new DbIngredient { Id = 6, Name = "Sok Pomarańczowy"},
                         new DbIngredient { Id = 7, Name = "Blue Curacao" },
                         new DbIngredient { Id = 8, Name = "Prosecco" },
                         new DbIngredient { Id = 9, Name = "Sok pomidorowy" },
                         new DbIngredient { Id = 10, Name = "Woda Gazowana" },
                         new DbIngredient { Id = 11, Name = "Sok Jabłkowy" },
                         new DbIngredient { Id = 12, Name = "Sok Porzeczkowy" },
                         new DbIngredient { Id = 13, Name = "Gin" },
                         new DbIngredient { Id = 14, Name = "Malibu" },
                         new DbIngredient { Id = 15, Name = "Aperol" },
                         new DbIngredient { Id = 16, Name = "Tequila" },
                         new DbIngredient { Id = 17, Name = "Jagermeister" },
                         new DbIngredient { Id = 18, Name = "Sok z cytryny" },
                         new DbIngredient { Id = 19, Name = "Syrop cukrowy" },
                         new DbIngredient { Id = 20, Name = "Grenadyna" },
                         new DbIngredient { Id = 21, Name = "Coca Cola" },
                         new DbIngredient { Id = 22, Name = "Sok z limonki" },
                         new DbIngredient { Id = 23, Name = "Limonka" },
                         new DbIngredient { Id = 24, Name = "Cytryna" },
                         new DbIngredient { Id = 25, Name = "Pomidor" },
                         new DbIngredient { Id = 26, Name = "Szpinak" },
                         new DbIngredient { Id = 27, Name = "Pomarańcza" },
                         new DbIngredient { Id = 28, Name = "Granat" },
                         new DbIngredient { Id = 29, Name = "Mięta" },
                         new DbIngredient { Id = 30, Name = "Truskawki" },
                         new DbIngredient { Id = 31, Name = "Avokado" },
                         new DbIngredient { Id = 32, Name = "Brzoskwinia" },
                         new DbIngredient { Id = 33, Name = "Banan" },
                         new DbIngredient { Id = 34, Name = "Miód" },
                         new DbIngredient { Id = 35, Name = "Winogrono Białe" },
                         new DbIngredient { Id = 36, Name = "Winogrono Czerwone" });
            modelBuilder.Entity<DbDrinkType>()
                .HasData(new DbDrinkType { Id = 1, Name = "Drink z alkoholem" },
                         new DbDrinkType { Id = 2, Name = "Shot" },
                         new DbDrinkType { Id = 3, Name = "Drink bezalkoholowy" });
            modelBuilder.Entity<DbMainIngredient>()
                .HasData(new DbMainIngredient { Id = 1, Name = "Vodka" },
                         new DbMainIngredient { Id = 2, Name = "Rum" },
                         new DbMainIngredient { Id = 3, Name = "Whisky" },
                         new DbMainIngredient { Id = 4, Name = "Sok pomidorowy" },
                         new DbMainIngredient { Id = 5, Name = "Gin" },
                         new DbMainIngredient { Id = 6, Name = "Aperol" },
                         new DbMainIngredient { Id = 7, Name = "Malibu" },
                         new DbMainIngredient { Id = 8, Name = "Jagermeister" },
                         new DbMainIngredient { Id = 9, Name = "Truskawka" },
                         new DbMainIngredient { Id = 10, Name = "Banan" });
        }
    }
}
