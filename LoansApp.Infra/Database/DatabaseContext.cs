using LoansApp.Domain.Etities;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Infra.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; } = null!;
        public DbSet<LoanEntity> Loan { get; set; } = null!;
    }
}