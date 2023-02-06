using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GreenFlamingosDbContext _greenFlamingosDbContext;
        public UserRepository(GreenFlamingosDbContext greenFlamingosDbContext)
        {
            _greenFlamingosDbContext = greenFlamingosDbContext;
        }

        public async Task AddUserToDB(DbUser user)
        {
            await _greenFlamingosDbContext.Users.AddAsync(user);
            await _greenFlamingosDbContext.SaveChangesAsync();
        }

        public async Task<List<DbUser>> GetAllUsers()
        {
            return await _greenFlamingosDbContext.Users.Include(ud => ud.UserDetails)
                                                       .Include(du => du.DrinkUsers)
                                                       .Where(u=>u.UserName != "Admin")
                                                       .ToListAsync();
        }

        public async Task<DbUser> GetUserById(Claim userId)
        {
           return await _greenFlamingosDbContext.Users.Include(ud => ud.UserDetails).FirstOrDefaultAsync(u => u.Id == userId.Value);
        }
        public async Task<DbUser> GetUserByLoginForm(DbUser user)
        {
            return await _greenFlamingosDbContext
                                  .Users
                                  .FirstOrDefaultAsync(u => u.UserMail == user.UserMail && u.Password == user.Password);
        }
    }
}
