using ASP_.NET_test_proj_1.Models;

namespace ASP_.NET_test_proj_1.Data.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> GetByIdAsync(int id);
        Task<List<UserAccount>> GetAllAsync();
        Task<UserAccount> GetByLoginAsync(string login);
        Task<bool> Add(UserAccount userAccount);
        Task<bool> UpdateAsync(UserAccount userAccount);
        Task<bool> DeleteAsync(int id);
        Task<bool> Save();
    }
}
