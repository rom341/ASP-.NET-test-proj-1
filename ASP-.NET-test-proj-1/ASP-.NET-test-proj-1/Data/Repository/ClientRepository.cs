using ASP_.NET_test_proj_1.Data.Interfaces;
using ASP_.NET_test_proj_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_test_proj_1.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AccountDBContext dBContext;

        public ClientRepository(AccountDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool Add(Client client)
        {
            dBContext.Add(client);
            return Save();
        }

        public bool DeleteAsync(int id)
        {
            dBContext.Remove(id);
            return Save();
        }

        public Task<List<Client>> GetAllAsync()
        {
            return dBContext.Clients.ToListAsync();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            return dBContext.Clients.FirstAsync(client => client.ID == id);
        }

        public bool Save()
        {
            return dBContext.SaveChanges() > 0;
        }

        public bool UpdateAsync(Client client)
        {
            dBContext.Update(client);
            return Save();
        }
    }
}
