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

        public async Task<bool> Add(UserAccount userAccount)
        {
            await dbContext.AddAsync(userAccount);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userAccount = await GetByIdAsync(id);
            if (userAccount == null) return false;

            dbContext.Remove(userAccount);
            return await Save();
        }

        public async Task<List<UserAccount>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserAccount?> GetByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.ID == id);
        }

        public async Task<UserAccount?> GetByLoginAsync(string login)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Login == login);
        }

        public async Task<bool> Save()
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UserAccount userAccount)
        {
            var existingUserAccount = await GetByIdAsync(userAccount.ID);
            if (existingUserAccount == null) return false;

            dbContext.Update(userAccount);
            return await Save();
        }
    }
}
