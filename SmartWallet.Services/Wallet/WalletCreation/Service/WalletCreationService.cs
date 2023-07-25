using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartWallet.CustomException;
using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;
using SmartWallet.Models.Wallet.WalletCreation;
using SmartWallet.Services.Wallet.WalletCreation.Interfaces;

namespace SmartWallet.Services.Wallet.WalletCreation.Service
{
    public class WalletCreationService : IWalletCreationService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WalletCreationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #region Public Methods
        /// <summary>
        /// This method is used to creation and activation of wallet againt the user into database
        /// </summary>
        /// <param name="walletModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> AddWallet(WalletModel walletModel)
        {
            string walletId = "";
            try
            {
                //Valdation is pending for KYC -- ATUL GHARGE 20 july 2023
                Wallets wallet = _mapper.Map<WalletModel, Wallets>(walletModel);
                await _unitOfWork.wallet.AddAsync(wallet);
                _unitOfWork.Complete();
                walletId = wallet.WalletID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return walletId;
        }
        #endregion


    }
}
