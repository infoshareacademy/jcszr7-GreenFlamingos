

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUserDetails
    {
        public int? Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public DbUser User { get; set; }
        public string UserId { get; set; }
    }
}
