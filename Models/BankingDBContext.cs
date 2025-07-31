using Microsoft.EntityFrameworkCore;

namespace Banking.Models
{
    public class BankingDBContext : DbContext
    {
        public BankingDBContext(DbContextOptions<BankingDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Transaction>? Transactions { get; set; }
    }
}
