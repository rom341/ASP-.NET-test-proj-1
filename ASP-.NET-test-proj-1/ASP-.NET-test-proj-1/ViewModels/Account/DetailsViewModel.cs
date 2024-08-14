using ASP_.NET_test_proj_1.Models;

namespace ASP_.NET_test_proj_1.ViewModels.Account
{
    public class DetailsViewModel
    {
        public UserAccount userAccount { get; set; }
        public DetailsViewModel(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
    }
}
