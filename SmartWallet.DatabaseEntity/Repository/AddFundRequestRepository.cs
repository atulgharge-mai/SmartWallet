using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;

namespace SmartWallet.DatabaseEntity.Repository
{
    public class AddFundRequestRepository : GenericRepository<AddFundRequests>, IAddFundRequestRepository
    {
        public AddFundRequestRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
