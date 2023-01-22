﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUser : IdentityUser
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public string Password { get; set; }
        public string UserMail { get; set; }
        public List<DbDrink> Drinks { get; set; } = new List<DbDrink>();
        public DbUserDetails UserDetails { get; set; }
    }
}
