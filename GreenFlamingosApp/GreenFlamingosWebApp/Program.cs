using GreenFlamingos.Repository;
using GreenFlamingos.Services;
using GreenFlamingos.Services.Interfaces;
using GreenFlamingosApp.DataBase;
using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddScoped<DrinkRepository>();

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
            City = "Gda�sk",
            Street = "D�uga 9",
            PhoneNumber = "111222333"
        }
    };
    await dbGreenFlamingos.Users.AddRangeAsync(user1,user2);
    await dbGreenFlamingos.SaveChangesAsync();
}

app.Run();
