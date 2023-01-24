using GreenFlamingos.Services.Services.Interfaces;
using GreenFlamingosApp.DataBase;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.Services.Services.Interfaces;
using GreenFlamingosApp.Services.Services.ServiceClass;
using GreenFlamingosApp.Services.Services.ServiceClasses;
using Microsoft.EntityFrameworkCore;
using GreenFlamingos.Model;
using FluentValidation;
using GreenFlamingos.Model.Users;
using Microsoft.AspNetCore.Identity;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDrinkRepository,DrinkRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IUserAutentication, UserAuthentication>();
//Identity
builder.Services.AddIdentity<DbUser, IdentityRole>()
                .AddEntityFrameworkStores<GreenFlamingosDbContext>()
                .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(opt => opt.LoginPath = "/UserAutentication/Login");
//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program),typeof(UserService));
//Add DbContext
builder.Services.AddDbContext<GreenFlamingosDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("GreenFlamingos")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
