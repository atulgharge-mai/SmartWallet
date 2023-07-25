using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartWallet.DatabaseEntity.Wallet;
using SmartWallet.Models.Wallet.AddFundRequest;
using SmartWallet.Models.Wallet.WalletCreation;
using SmartWallet.Models.Wallet.WithdrawFundRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWallet.Services.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AddFundRequests, AddFundRequestModel>();
            CreateMap<WithdrawFundRequestModel, WithdrawFundRequestModel>();
        }
    }
}
