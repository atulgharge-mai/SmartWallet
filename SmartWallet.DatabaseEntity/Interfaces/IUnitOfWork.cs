namespace SmartWallet.DatabaseEntity.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWalletRepository wallet { get; }
        IAddFundRequestRepository addFundRequest { get; }
        IWithdrawFundRequestRepository withdrawFundRequest { get;  }
        IWalletTransactionRepository walletTransaction { get; }

        int Complete();
    }
}
