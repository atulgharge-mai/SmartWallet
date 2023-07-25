using SmartWallet.Models.Wallet.WithdrawFundRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWallet.Services.Wallet.WithdrawFundRequest.Interfaces
{
    public interface IWithdrawFundWalletRequestService
    {
        Task<string> WithDrawFundRequestFromWallet(WithdrawFundRequestModel withdrawFundRequestModel);
    }
}
