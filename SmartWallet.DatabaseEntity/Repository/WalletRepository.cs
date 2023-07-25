using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;

namespace SmartWallet.DatabaseEntity.Repository
{
    public class WalletRepository : GenericRepository<Wallets>, IWalletRepository
    {
        public WalletRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
