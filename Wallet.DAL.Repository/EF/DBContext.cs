using Microsoft.EntityFrameworkCore;
using Wallet.Common.Entities.User.DB;

namespace Wallet.DAL.Repository.EF
{
    public class DBContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public DBContext(DbContextOptions<DBContext> options, IServiceProvider serviceProvider)
            : base(options)
        {
            _serviceProvider = serviceProvider; 
        }
    }
}
