using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        public bool Login(string username, string password)
        {
            return Username == username && Password == password; 
        }
    }
}
