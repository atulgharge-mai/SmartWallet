using Microsoft.AspNetCore.Mvc;
using SmartWallet.Models.Common;
using SmartWallet.Models.Wallet.AddFundRequest;
using SmartWallet.Models.Wallet.WalletCreation;
using SmartWallet.Models.Wallet.WithdrawFundRequest;
using SmartWallet.Services.Wallet.AddFundRequest.Interfaces;
using SmartWallet.Services.Wallet.WalletCreation.Interfaces;
using SmartWallet.Services.Wallet.WithdrawFundRequest.Interfaces;
using SmartWallet.WebAPI.Constants;

namespace SmartWallet.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SmartWalletController : Controller
    {
        private readonly ILogger<SmartWalletController> _logger;
        private readonly IWalletCreationService _walletCreationService;
        private readonly IAddFundWalletRequestService _addFundWalletRequestService;
        private readonly IWithdrawFundWalletRequestService _withdrawFundWalletRequestService;


        public SmartWalletController(ILogger<SmartWalletController> logger, IWalletCreationService walletCreationService, IAddFundWalletRequestService addFundWalletRequestService, IWithdrawFundWalletRequestService withdrawFundWalletRequestService)
        {
            _logger = logger;
            _walletCreationService = walletCreationService;
            _addFundWalletRequestService = addFundWalletRequestService;
            _withdrawFundWalletRequestService = withdrawFundWalletRequestService;
        }

        /// <summary>
        /// It is used to created or activate the wallet
        /// </summary>
        /// <param name="walletModel"></param>
        /// <returns>ServiceResponse</returns>
        [HttpPost("walletCreation")]
        public async Task<ActionResult<ServiceResponse<string>>> WalletCreation(WalletModel walletModel)
        {
            var response = new ServiceResponse<string>();
            try
            {
                _logger.LogInformation("Wallet creation request- " + Newtonsoft.Json.JsonConvert.SerializeObject(walletModel));
                string walletID = await _walletCreationService.AddWallet(walletModel);
                if (!string.IsNullOrEmpty(walletID))
                {
                    response.Data = walletID;
                    response.Success = true;
                    response.Message = ConstantMessages.WALLET_ADDED_SUCCESS;
                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = ConstantMessages.WALLET_NOT_ADDED_FAILED;
                }
                _logger.LogInformation("Wallet creation response- " + Newtonsoft.Json.JsonConvert.SerializeObject(response));

            }
            catch (Exception ex)
            {
                // logging error
                _logger.LogError(ex.Message + ex.StackTrace);
                response.Success = false;
                response.Message = ex.Message + ex.InnerException;
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("addWalletFundRequest")]
        public async Task<ActionResult<ServiceResponse<string>>> AddWalletFundRequest(AddFundRequestModel addFundRequestModel)
        {
            var response = new ServiceResponse<string>();
            try
            {
                _logger.LogInformation("Add walletFundRequest request - " + Newtonsoft.Json.JsonConvert.SerializeObject(addFundRequestModel));
                string walletID = await _addFundWalletRequestService.AddFundRequestToWallet(addFundRequestModel);
                if (!string.IsNullOrEmpty(walletID))
                {
                    response.Data = walletID;
                    response.Success = true;
                    response.Message = ConstantMessages.WALLET_BALANCE_ADDED_SUCCESS;
                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = ConstantMessages.WALLET_BALANCE_ADDED_FAILED;
                }
                _logger.LogInformation("Add walletFundRequest response - " + Newtonsoft.Json.JsonConvert.SerializeObject(addFundRequestModel));
            }
            catch (Exception ex)
            {
                // logging error
                _logger.LogError(ex.Message + ex.StackTrace);
                response.Success = false;
                response.Message = ex.Message + ex.InnerException;
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("withdraWalletFundRequest")]
        public async Task<ActionResult<ServiceResponse<string>>> WithdraWalletFundRequest(WithdrawFundRequestModel withdrawFundRequestModel)
        {
            var response = new ServiceResponse<string>();
            try
            {
                _logger.LogInformation("Add withdraWalletFundRequest request - " + Newtonsoft.Json.JsonConvert.SerializeObject(withdrawFundRequestModel));
                string walletID = await _withdrawFundWalletRequestService.WithDrawFundRequestFromWallet(withdrawFundRequestModel);
                if (!string.IsNullOrEmpty(walletID))
                {
                    response.Data = walletID;
                    response.Success = true;
                    response.Message = ConstantMessages.WALLET_BALANCE_WITHDRAW_SUCCESS;
                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = ConstantMessages.WALLET_BALANCE_WITHDRAW_FAILED;
                }
                _logger.LogInformation("Add withdraWalletFundRequest response - " + Newtonsoft.Json.JsonConvert.SerializeObject(withdrawFundRequestModel));
            }
            catch (Exception ex)
            {
                // logging error
                _logger.LogError(ex.Message + ex.StackTrace);
                response.Success = false;
                response.Message = ex.Message + ex.InnerException;
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
