using ASP_.NET_test_proj_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_test_proj_1.Data
{
    public class AccountDBContext : DbContext
    {
        public AccountDBContext(DbContextOptions<AccountDBContext> options) : base(options)
        {

        }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
