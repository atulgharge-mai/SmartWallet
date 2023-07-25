using SmartWallet.DatabaseEntity.Interfaces;

namespace SmartWallet.DatabaseEntity.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            wallet = new WalletRepository(_context);
            addFundRequest = new AddFundRequestRepository(_context);
            withdrawFundRequest = new WithdrawFundRequestRepository(_context);
            walletTransaction = new WalletTransactionRepository(_context);
        }
        public IWalletRepository wallet { get; private set; }
        public IAddFundRequestRepository addFundRequest { get; private set; }
        public IWithdrawFundRequestRepository withdrawFundRequest { get; private set; }
        public IWalletTransactionRepository walletTransaction { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
