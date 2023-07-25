using AutoMapper;
using SmartWallet.CustomException;
using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;
using SmartWallet.Models.Wallet.WithdrawFundRequest;
using SmartWallet.Services.Wallet.WithdrawFundRequest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWallet.Services.Wallet.WithdrawFundRequest.Service
{
    public class WithdrawFundRequestService : IWithdrawFundWalletRequestService
    {
        private IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WithdrawFundRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Public Method

        /// <summary>
        /// This method used to withdraw fund from wallet
        /// </summary>
        /// <param name="withdrawFundRequestModel"></param>
        /// <returns></returns>
        public async Task<string> WithDrawFundRequestFromWallet(WithdrawFundRequestModel withdrawFundRequestModel)
        {
            string walletTransactionID = "";
            Wallets wallets;
            try
            {
                #region validation check
                ValidationHelper.IsPositive(withdrawFundRequestModel.Amount);
                ValidationHelper.IsWalletSufficientBalance(withdrawFundRequestModel.WalletID, withdrawFundRequestModel.Amount, _unitOfWork, out wallets);
                wallets.WalletBalance -= withdrawFundRequestModel.Amount; // wallet balance update
                #endregion

                #region multiple table records insertion operation
                WithdrawFundRequests withdrawFundRequests = mapper.Map<WithdrawFundRequestModel, WithdrawFundRequests>(withdrawFundRequestModel);

                WalletTransactions walletTransactions = new WalletTransactions
                {
                    AddWalletTransactionID = Guid.NewGuid(),
                    UserID = withdrawFundRequestModel.UserID,
                    WalletID = withdrawFundRequestModel.WalletID,
                    FundRequestID = withdrawFundRequests.WithdrawFundRequestID,
                    TransactionNumber = "123", //Payment Gateway response
                    TrackingID = "100000",
                    TransactionDate = DateTime.UtcNow, //Need to discuss about Date format 
                    BankRefNo = "12344",
                    PaymentMode = "Phone Banking",
                    Description = "test",
                    Status = "Progess",
                    Amount = withdrawFundRequestModel.Amount,
                    Currency = withdrawFundRequestModel.Currency,
                    TransactionType = "Credit",
                    Remark = withdrawFundRequestModel.Remark,
                    CreatedDate = withdrawFundRequestModel.CreatedDate,
                    CreatedByID = withdrawFundRequestModel.CreatedByID,
                    ModifiedDate = withdrawFundRequestModel.ModifiedDate,
                    ModifiedByID = withdrawFundRequestModel.ModifiedByID
                };

                await _unitOfWork.withdrawFundRequest.AddAsync(withdrawFundRequests);
                await _unitOfWork.walletTransaction.AddAsync(walletTransactions);
                _unitOfWork.wallet.Update(wallets);
                _unitOfWork.Complete();
                #endregion

                walletTransactionID = walletTransactions.AddWalletTransactionID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return walletTransactionID;
        }
        #endregion
    }
}
