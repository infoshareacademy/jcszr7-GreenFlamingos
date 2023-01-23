﻿using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GreenFlamingosApp.DataBase.DbModels.Identity;
using GreenFlamingosApp.Services.Services.Interfaces;

namespace GreenFlamingosWebApp.Controllers
{
    public class UserAutentication : Controller
    {
        private readonly IUserAutentication _userAutenticationService;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public UserAutentication(IUserAutentication userAutenticationService, IConfiguration config, IUserService userService)
        {
            _userAutenticationService = userAutenticationService;
            _config = config;
            _userService = userService;
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
            await _userAutenticationService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var result = await _userAutenticationService.LoginAsync(loginModel);
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
            var result = await _userAutenticationService.RegistrationAsync(model);
            if(result.StatusCode == 1)
            {
                _userService.SendEmail(model.Email,model.Name);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(RegisterUser));
        }
    }
}
