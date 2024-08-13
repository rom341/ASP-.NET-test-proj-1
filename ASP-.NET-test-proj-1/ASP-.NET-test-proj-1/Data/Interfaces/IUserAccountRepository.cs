using ASP_.NET_test_proj_1.Models;

namespace ASP_.NET_test_proj_1.Data.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> GetByIdAsync(int id);
        Task<List<UserAccount>> GetAllAsync();
        Task<UserAccount> GetByLoginAsync(string login);
        bool Add(UserAccount userAccount);
        bool UpdateAsync(UserAccount userAccount);
        bool DeleteAsync(int id);
        bool Save();
    }
}
