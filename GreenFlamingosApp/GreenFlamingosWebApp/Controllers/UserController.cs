using AutoMapper;
using FluentValidation.Results;
using GreenFlamingos.Model;
using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
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
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
        public ActionResult LogOut(User user)
        {
            user = null;
            return RedirectToAction("Index", "Home", user);
        }

        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            try
            {
                var userToLog = _mapper.Map<DbUser>(user);
                var loggedUser = await _userService.LoginUser(userToLog);
                if(loggedUser != null)
                {
                    var mappedLoggedUser = _mapper.Map<User>(loggedUser);
                    return View("../Home/Index", mappedLoggedUser);
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
        public void SendEmail(string receiver)
        {
            var fromMail = "GreenFlamingosApp@gmail.com";
            var fromPassword = "pldmwbffjatkkvmy";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Green Flamingos Potwierdzenie Rejestracji ";
            message.To.Add(new MailAddress(receiver));
            message.Body = "<html><body> Gratulacje! Pomyślnie zalożyłeś konto w serwisie GreeenFlamingos :)</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
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
        // GET: UserController/RegisterUser
        public ActionResult RegisterUser()
        {
            return View();
        }
        // POST: UserController/RegisterUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            try
            {
                var createdUser = _mapper.Map<DbUser>(user);
                UserValidator validator = new UserValidator();
                var result = validator.Validate(user);
                foreach(ValidationFailure fail in result.Errors)
                {
                    ModelState.AddModelError("RepeatedPassword", fail.ErrorMessage);
                }
                if(result.IsValid)
                {
                    _userService.RegisterUser(createdUser);
                    SendEmail(createdUser.UserMail);
                    //var HomeController = new HomeController();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
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
