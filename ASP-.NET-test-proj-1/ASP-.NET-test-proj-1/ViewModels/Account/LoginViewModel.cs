using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_test_proj_1.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
