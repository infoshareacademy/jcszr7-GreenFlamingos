using AutoMapper;
using FluentValidation.Results;
using GreenFlamingos.Model;
using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            try
            {
                //var createdUser = _mapper.Map<DbUser>(user);
                //_userService.RegisterUser(createdUser);
                UserValidator validator = new UserValidator();
                ValidationResult result = validator.Validate(user);
                if(result.IsValid)
                {
                    return RedirectToAction(nameof(RegisterUser));
                }
                return RedirectToAction(nameof(DrinkController.Index));
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
