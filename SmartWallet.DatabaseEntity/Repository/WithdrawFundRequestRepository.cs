using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;

namespace SmartWallet.DatabaseEntity.Repository
{
    public class WithdrawFundRequestRepository : GenericRepository<WithdrawFundRequests>, IWithdrawFundRequestRepository
    {
        public WithdrawFundRequestRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
