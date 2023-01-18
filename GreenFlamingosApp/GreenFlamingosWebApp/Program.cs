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

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<GreenFlamingosApp.DataBase.GreenFlamingosRepository.DrinkRepository>();
builder.Services.AddScoped<GreenFlamingosApp.DataBase.GreenFlamingosRepository.UserRepository>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Database Concept
using var scope = app.Services.CreateScope();
var dbGreenFlamingos = scope.ServiceProvider.GetService<GreenFlamingosDbContext>();

var users = await dbGreenFlamingos.Users.ToListAsync();

if(!users.Any())
{
    var user1 = new DbUser()
    {
        UserMail = "Jakub.Gruszczyk@test.com",
        Password = "Firanka111!",
        UserDetails = new DbUserDetails()
        {
            City = "Rumia",
            Street = "Szeroka 8",
            PhoneNumber = "777555888"
        }
    };
    var user2 = new DbUser()
    {
        UserMail = "ewa.rabenda18@test.com",
        Password = "Slonik223!",
        UserDetails = new DbUserDetails()
        {
            City = "Gdañsk",
            Street = "D³uga 9",
            PhoneNumber = "111222333"
        }
    };
    await dbGreenFlamingos.Users.AddRangeAsync(user1,user2);
    await dbGreenFlamingos.SaveChangesAsync();
}

app.Run();
