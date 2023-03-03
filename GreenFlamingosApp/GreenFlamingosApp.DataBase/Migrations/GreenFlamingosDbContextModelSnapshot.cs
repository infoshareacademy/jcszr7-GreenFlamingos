﻿// <auto-generated />
using System;
using GreenFlamingosApp.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    [DbContext(typeof(GreenFlamingosDbContext))]
    partial class GreenFlamingosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AlcoholContent")
                        .HasColumnType("real");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrinkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainIngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preparations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId1");

                    b.HasIndex("DrinkTypeId");

                    b.HasIndex("MainIngredientId");

                    b.ToTable("DbDrinks");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrinkIngredient", b =>
                {
                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("IngredientCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DrinksIngredients");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrinkTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drink z alkoholem"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shot"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drink bezalkoholowy"
                        });
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrinkUser", b =>
                {
                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DbProposedDrinkId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("DrinkId", "UserId");

                    b.HasIndex("DbProposedDrinkId");

                    b.HasIndex("UserId");

                    b.ToTable("DrinkUsers");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Wódka"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rum"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Whisky"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kostki lodu"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Woda"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sok Pomarańczowy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Blue Curacao"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Prosecco"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sok pomidorowy"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Woda Gazowana"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Sok Jabłkowy"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Sok Porzeczkowy"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Malibu"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Aperol"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Tequila"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Jagermeister"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Sok z cytryny"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Syrop cukrowy"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Grenadyna"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Coca Cola"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Sok z limonki"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Limonka"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Cytryna"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Pomidor"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Szpinak"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Pomarańcza"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Granat"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Mięta"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Truskawki"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Avokado"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Brzoskwinia"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Banan"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Miód"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Winogrono Białe"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Winogrono Czerwone"
                        });
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbMainIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbMainIngredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Wódka"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rum"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Whisky"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sok pomidorowy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Aperol"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Malibu"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Jagermeister"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Truskawka"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Banan"
                        });
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbProposedDrink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AlcoholContent")
                        .HasColumnType("real");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrinkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainIngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preparations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId1");

                    b.HasIndex("DrinkTypeId");

                    b.HasIndex("MainIngredientId");

                    b.ToTable("ProposedDrinks");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbProposedDrinkIngredient", b =>
                {
                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("IngredientCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ProposedDrinkIngriedents");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbUserDetails", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrink", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId1");

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbDrinkType", "DrinkType")
                        .WithMany()
                        .HasForeignKey("DrinkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbMainIngredient", "MainIngredient")
                        .WithMany()
                        .HasForeignKey("MainIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("DrinkType");

                    b.Navigation("MainIngredient");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrinkIngredient", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbDrink", "Drink")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbIngredient", "Ingredient")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrinkUser", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbProposedDrink", null)
                        .WithMany("DrinkUsers")
                        .HasForeignKey("DbProposedDrinkId");

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbDrink", "Drink")
                        .WithMany("DrinkUsers")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", "User")
                        .WithMany("DrinkUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbProposedDrink", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId1");

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbDrinkType", "DrinkType")
                        .WithMany()
                        .HasForeignKey("DrinkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbMainIngredient", "MainIngredient")
                        .WithMany()
                        .HasForeignKey("MainIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("DrinkType");

                    b.Navigation("MainIngredient");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbProposedDrinkIngredient", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbProposedDrink", "ProposedDrink")
                        .WithMany("ProposedDrinkIngredients")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbIngredient", "Ingredient")
                        .WithMany("ProposedDrinkIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("ProposedDrink");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbUserDetails", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("GreenFlamingosApp.DataBase.DbModels.DbUserDetails", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GreenFlamingosApp.DataBase.DbModels.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbDrink", b =>
                {
                    b.Navigation("DrinkIngredients");

                    b.Navigation("DrinkUsers");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbIngredient", b =>
                {
                    b.Navigation("DrinkIngredients");

                    b.Navigation("ProposedDrinkIngredients");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbProposedDrink", b =>
                {
                    b.Navigation("DrinkUsers");

                    b.Navigation("ProposedDrinkIngredients");
                });

            modelBuilder.Entity("GreenFlamingosApp.DataBase.DbModels.DbUser", b =>
                {
                    b.Navigation("DrinkUsers");

                    b.Navigation("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
