using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUserDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        //public DbUser User { get; set; }
        //public int UserId { get; set; }
    }
}
