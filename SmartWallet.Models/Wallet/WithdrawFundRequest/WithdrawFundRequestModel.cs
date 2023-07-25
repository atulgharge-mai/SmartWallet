using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartWallet.Models.Wallet.WithdrawFundRequest
{
    public class WithdrawFundRequestModel
    {
        #region Private Fields
        private Guid _withdrawFundRequestID;
        private Guid _walletID;
        private Guid _userID;
        private string _requestType = "";
        private DateTime _requestDate;
        private string _description = "";
        private decimal _amount = 0;
        private string _currency = "";
        private string _remark = "";
        private DateTime _processedDate;
        private int _status;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private Guid _createdByID;
        private Guid _modifiedByID;
        #endregion

        #region Public Property
       
        public Guid WithdrawFundRequestID { get => _withdrawFundRequestID; set => _withdrawFundRequestID = value; }
        public Guid WalletID { get => _walletID; set => _walletID = value; }
        public Guid UserID { get => _userID; set => _userID = value; }
        public string RequestType { get => _requestType; set => _requestType = value; }
        public DateTime RequestDate { get => _requestDate; set => _requestDate = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        public string Currency { get => _currency; set => _currency = value; }
        public string Remark { get => _remark; set => _remark = value; }
        public DateTime ProcessedDate { get => _processedDate; set => _processedDate = value; }
        public int Status { get => _status; set => _status = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
        public Guid CreatedByID { get => _createdByID; set => _createdByID = value; }
        public Guid ModifiedByID { get => _modifiedByID; set => _modifiedByID = value; }
        #endregion
    }
}
