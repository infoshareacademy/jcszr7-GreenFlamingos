﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public class UserRegister
    {
        private User _user;
        public UserRegister(User user)
        {
            _user = user;
        }

        public User RecordUser()
        {
            var userValidation = new UserDataValidation(_user);
            string userMail = userValidation.EmailValidation();
            string password = userValidation.PasswordValidation();
            var user = new User(password, userMail);
            return user;
        }


    }
}