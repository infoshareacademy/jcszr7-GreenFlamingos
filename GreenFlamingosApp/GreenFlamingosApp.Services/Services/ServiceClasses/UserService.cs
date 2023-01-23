using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository;
using GreenFlamingosApp.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

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

        public Task<DbUser> LoginUser(DbUser user)
        {
           return _userRepository.GetUserByLoginForm(user);
        }

        public async Task RegisterUser(DbUser user)
        {
            await _userRepository.AddUserToDB(user);
        }

        public void SendEmail(string receiver, string userName)
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
    }
}
