using SmartWallet.DatabaseEntity.Interfaces;
using SmartWallet.DatabaseEntity.Wallet;
using SmartWallet.Models.Wallet.WalletCreation;
using SmartWallet.WebAPI.Constants;
using System.Net;

namespace SmartWallet.CustomException
{
    public static class ValidationHelper
    {

        #region Data Formating VAlidation
        /// <summary>
        /// This validation is used to check  amount should be positive
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="UserCustomException"></exception>
        public static void IsPositive(decimal amount)
        {
            if (amount <= 0) throw new UserCustomException(ConstantMessages.AMOUNT_NOT_VALID_FAILED, (int)HttpStatusCode.BadRequest);
        }
        #endregion

        #region Database validation Methods

        /// <summary>
        ///  This validation is used to check wheather wallet exist in db or not
        /// </summary>
        /// <param name="walletID"></param>
        /// <exception cref="UserCustomException"></exception>
        public static void IsWalletExist(Guid walletID, IUnitOfWork _unitOfWork, out Wallets wallet)
        {
            walletID = Guid.NewGuid();
            Wallets? wallets = _unitOfWork.wallet.Find(x => x.WalletID == walletID).FirstOrDefault();
            if (wallets == null)
            {
                throw new UserCustomException(ConstantMessages.WALLET_NOT_FOUND_FAILED, (int)HttpStatusCode.BadRequest);
            }
            wallet = wallets;
        }
       
        /// <summary>
        /// This validation is used to check withdraw amount should not greater than wallet balace
        /// </summary>
        /// <param name="walletID"></param>
        /// <param name="amount"></param>
        public static void IsWalletSufficientBalance(Guid walletID, decimal amount, IUnitOfWork _unitOfWork, out Wallets wallet)
        {
            Wallets? wallets = _unitOfWork.wallet.Find(x => x.WalletID == walletID).FirstOrDefault();
            if (wallets != null)
            {
                if (amount >= Convert.ToDecimal(wallets.WalletBalance)) throw new UserCustomException(ConstantMessages.WALLET_BALANCE_INSUFFICIENT_FAILED, (int)HttpStatusCode.BadRequest);
            }
            else
            {
                throw new UserCustomException(ConstantMessages.WALLET_NOT_FOUND_FAILED, (int)HttpStatusCode.BadRequest);
            }
            wallet = wallets;
        }


        #endregion

    }
}