using ASP_.NET_test_proj_1.Models;

namespace ASP_.NET_test_proj_1.ViewModels.Account
{
    public class IndexViewModel
    {
        public List<UserAccount> userAccounts { get; set; }

        public IndexViewModel(List<UserAccount> userAccounts)
        {
            this.userAccounts = userAccounts;
        }
    }
}
