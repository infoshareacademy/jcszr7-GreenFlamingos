using AutoMapper;
using GreenFlamingosApp.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace GreenFlamingosWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IMapper mapper, IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        // GET: UserController/Login
        public ActionResult Login()
        {
            return View();
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

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
