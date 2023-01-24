using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.DbModels.Identity;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository
{
    public class UserAuthentication : IUserAutentication
    {
        private readonly SignInManager<DbUser> _signInManager;
        private readonly UserManager<DbUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserAuthentication(SignInManager<DbUser> signInManager, UserManager<DbUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<DbUser> GetUserById(Claim userId)
        {
            return await _userManager.FindByIdAsync(userId.Value);
        }

        public async Task<Status> LoginAsync(LoginModel loginModel)
        {
            var status = new Status();
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "User does not exist";
                return status;
            }
            //match password
            if (!await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid password";
                return status;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                status.StatusCode = 1;
                status.Message = "Logged in";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User locked out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on loggin in";
                return status;
            }
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Status> RegistrationAsync(Registration registration)
        {
            var status = new Status();
            var userExists = await _userManager.FindByNameAsync(registration.login);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User Already exist";
                return status;
            }
            DbUser dbUser = new DbUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registration.login,
                UserMail = registration.Email,
                UserDetails = registration.UserDetails,
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(dbUser, registration.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return status;
            }

            //role managmetn
            if (!await _roleManager.RoleExistsAsync(registration.Role))
                await _roleManager.CreateAsync(new IdentityRole(registration.Role));

            if (await _roleManager.RoleExistsAsync(registration.Role))
            {
                await _userManager.AddToRoleAsync(dbUser, registration.Role);
            }

            status.StatusCode = 1;
            status.Message = "You have registered successfully";
            return status;
        }
    }
}
