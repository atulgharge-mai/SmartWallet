using SmartWallet.Models.Wallet.AddFundRequest;

namespace SmartWallet.Services.Wallet.AddFundRequest.Interfaces
{
    public interface IAddFundWalletRequestService
    {
        Task<string> AddFundRequestToWallet(AddFundRequestModel addFundRequestModel);
    }
}
