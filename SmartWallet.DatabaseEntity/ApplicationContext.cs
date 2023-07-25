using Microsoft.EntityFrameworkCore;
using SmartWallet.DatabaseEntity.Wallet;

namespace SmartWallet.DatabaseEntity
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Wallets> wallets { get; set; }
        public DbSet<AddFundRequests> addFundRequests { get; set; }
        public DbSet<WithdrawFundRequests> withdrawFundRequests { get; set; }
        public DbSet<WalletTransactions> walletTransactions { get; set; }

    }
}
