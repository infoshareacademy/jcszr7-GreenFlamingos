using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Net.Mail;
using System.Net;

namespace GreenFlamingosWebApp.Controllers
{
    public class UserAutentication : Controller
    {
        private readonly IUserAutentication _userService;
        private readonly IConfiguration _config;

        public UserAutentication(IUserAutentication userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutAsync();
            return RedirectToAction("Index", "Home");
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
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var result = await _userService.LoginAsync(loginModel);
            if (result.StatusCode == 1)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await _userService.RegistrationAsync(model);
            if(result.StatusCode == 1)
            {
                SendEmail(model.Email,model.Name);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(RegisterUser));
        }
    }
}
