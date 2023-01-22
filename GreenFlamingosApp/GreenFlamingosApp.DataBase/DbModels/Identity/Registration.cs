﻿using GreenFlamingosApp.DataBase.DbModels;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingos.Model.Users
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }
        public string login { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Błędne hasło")]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? Role { get; set; }
        public DbUserDetails UserDetails { get; set; }
    }
}
