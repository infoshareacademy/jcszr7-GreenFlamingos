using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository;
using GreenFlamingosApp.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace GreenFlamingosApp.Services.Services.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task DeleteUser(DbUser user)
        {
            await _userRepository.DeleteUser(user.Id);
        }

        public async Task<List<DbUser>> GetAllUsers()
        {
           return await _userRepository.GetAllUsers();
        }

        public async Task<DbUser> GetUserById(string userId)
        {
            return await _userRepository.GetUserById(userId);
           
        }

        public void SendEmail(string receiver, string userName)
        {
            try
            {

                var fromMail = _config.GetSection("EmailUserName").Value;
                var fromPassword = _config.GetSection("EmailPassword").Value;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Green Flamingos Potwierdzenie Rejestracji ";
                message.To.Add(new MailAddress(receiver));
                message.Body = $"<html><body> <div>Witaj użytkowniku {userName} !</div>  <div>Pomyślnie zalożyłeś konto w serwisie GreeenFlamingos :)</div></body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient(_config.GetSection("EmailHost").Value)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true
                };
                smtpClient.Send(message);

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }
    }

