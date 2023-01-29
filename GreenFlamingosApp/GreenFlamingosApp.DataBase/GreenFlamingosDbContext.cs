﻿using GreenFlamingos.Model.Users;
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
                .HasData(new DbIngredient { Id = 1, Name = "Wódka" },
                         new DbIngredient { Id = 2, Name = "Rum" },
                         new DbIngredient { Id = 3, Name = "Whisky" },
                         new DbIngredient { Id = 4, Name = "Kostki lodu" },
                         new DbIngredient { Id = 5, Name = "Woda" },
                         new DbIngredient { Id = 6, Name = "Sok Pomarańczowy" });
            modelBuilder.Entity<DbDrinkType>()
                .HasData(new DbDrinkType { Id = 1, Name = "Drink z alkoholem" },
                         new DbDrinkType { Id = 2, Name = "Shot" },
                         new DbDrinkType { Id = 3, Name = "Drink bezalkoholowy" });
            modelBuilder.Entity<DbMainIngredient>()
                .HasData(new DbMainIngredient { Id = 1, Name = "Wódka" },
                         new DbMainIngredient { Id = 2, Name = "Rum" },
                         new DbMainIngredient { Id = 3, Name = "Whisky" },
                         new DbMainIngredient { Id = 4, Name = "Sok pomidorowy" });
        }
    }
}
