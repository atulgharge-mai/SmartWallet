using SmartWallet.Models.Wallet;
using SmartWallet.Models.Wallet.WalletCreation;

namespace SmartWallet.Services.Wallet.WalletCreation.Interfaces
{
    public interface IWalletCreationService
    {
        Task<string> AddWallet(WalletModel walletModel);
    }
}
