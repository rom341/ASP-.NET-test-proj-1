using ASP_.NET_test_proj_1.Data.Interfaces;
using ASP_.NET_test_proj_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_test_proj_1.Data.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AccountDBContext dbContext;

        public UserAccountRepository(AccountDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(UserAccount userAccount)
        {
            dbContext.Add(userAccount);
            return Save();
        }

        public bool DeleteAsync(int id)
        {
            dbContext.Remove(id);
            return Save();
        }

        public Task<List<UserAccount>> GetAllAsync()
        {
            return dbContext.Users.ToListAsync();
        }

        public Task<UserAccount> GetByIdAsync(int id)
        {
            return dbContext.Users.FirstAsync(user => user.ID == id);
        }

        public bool Save()
        {
            return dbContext.SaveChanges() > 0;
        }

        public bool UpdateAsync(UserAccount userAccount)
        {
            dbContext.Update(userAccount);
            return Save();
        }
    }
}
