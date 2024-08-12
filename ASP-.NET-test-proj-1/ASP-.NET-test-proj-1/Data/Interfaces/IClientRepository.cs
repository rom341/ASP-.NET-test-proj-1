using ASP_.NET_test_proj_1.Models;

namespace ASP_.NET_test_proj_1.Data.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
        bool Add(Client client);
        bool UpdateAsync(Client client);
        bool DeleteAsync(int id);
        bool Save();
    }
}
