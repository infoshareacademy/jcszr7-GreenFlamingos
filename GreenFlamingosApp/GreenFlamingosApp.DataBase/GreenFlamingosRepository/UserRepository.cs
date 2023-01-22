using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository
{
    public class UserRepository
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
        public async Task<DbUser> GetUserById(int id)
        {
            var user = new DbUser();
            return user;
            //return await _greenFlamingosDbContext.Users.Include(ud => ud.UserDetails)
            //                                           .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<DbUser> GetUserByLoginForm(DbUser user)
        {
            return await _greenFlamingosDbContext
                                  .Users
                                  .FirstOrDefaultAsync(u => u.UserMail == user.UserMail && u.Password == user.Password);
        }
    }
}
