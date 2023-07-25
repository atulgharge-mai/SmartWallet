using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;

namespace SmartWallet.DatabaseEntity.Repository
{
    public class WalletTransactionRepository : GenericRepository<WalletTransactions>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
