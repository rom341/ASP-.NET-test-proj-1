using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_test_proj_1.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            
        }
        public UserAccount(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        [Key]
        public int ID { get; private set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
    }
}
