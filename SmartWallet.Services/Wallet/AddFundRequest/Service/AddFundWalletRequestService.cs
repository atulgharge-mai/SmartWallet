using AutoMapper;
using SmartWallet.CustomException;
using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;
using SmartWallet.Models.Wallet.AddFundRequest;
using SmartWallet.Services.Wallet.AddFundRequest.Interfaces;

namespace SmartWallet.Services.Wallet.AddFundRequest.service
{
    public class AddFundWalletRequestService : IAddFundWalletRequestService
    {
        private IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddFundWalletRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// This method is used to add fund request in to database
        /// </summary>
        /// <param name="addFundRequestModel"></param>
        /// <returns></returns>
        public async Task<string> AddFundRequestToWallet(AddFundRequestModel addFundRequestModel)
        {
            string walletTransactionID = "";
            Wallets wallet;
            try
            {
                #region validation check
                ValidationHelper.IsPositive(addFundRequestModel.Amount);
                ValidationHelper.IsWalletExist(addFundRequestModel.WalletID, _unitOfWork, out wallet);
                #endregion

                #region multiple table records insertion operation

                AddFundRequests addFundRequest = mapper.Map<AddFundRequestModel, AddFundRequests>(addFundRequestModel);
                WalletTransactions walletTransactions = new WalletTransactions
                {
                    AddWalletTransactionID = Guid.NewGuid(),
                    UserID = addFundRequestModel.UserID,
                    WalletID = addFundRequestModel.WalletID,
                    FundRequestID = addFundRequest.AddFundRequestID,
                    TransactionNumber = "123", //Payment Gateway response
                    TrackingID = "100000",
                    TransactionDate = DateTime.UtcNow, //Need to discuss about Date format 
                    BankRefNo = "12344",
                    PaymentMode = "Phone Banking",
                    Description = "test",
                    Status = "Process",
                    Amount = addFundRequestModel.Amount,
                    Currency = addFundRequestModel.Currency,
                    TransactionType = "Credit",
                    Remark = addFundRequestModel.Remark,
                    CreatedDate = addFundRequestModel.CreatedDate,
                    CreatedByID = addFundRequestModel.CreatedByID,
                    ModifiedDate = addFundRequestModel.ModifiedDate,
                    ModifiedByID = addFundRequestModel.ModifiedByID
                };
                wallet.WalletBalance += addFundRequestModel.Amount; // wallet balance update
                await _unitOfWork.addFundRequest.AddAsync(addFundRequest);
                await _unitOfWork.walletTransaction.AddAsync(walletTransactions);
                _unitOfWork.wallet.Update(wallet);
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

    }
}
