using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWallet.DatabaseEntity.Wallet
{
    [Table("WalletTransactions")]
    public class WalletTransactions
    {
        #region Private Fields
        private Guid _addWalletTransactionID = Guid.NewGuid();
        private Guid _userID;
        private Guid _WalletID;
        private Guid _FundRequestID;
        private string _transactionNumber;
        private string _trackingID;
        private DateTime _transactionDate;
        private string _bankRefNo;
        private string _paymentMode;
        private string _description;
        private string _status;
        private decimal _amount;
        private string _currency;
        private string _transactionType;
        private string _remark; 
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private Guid _createdByID;
        private Guid _modifiedByID;
        #endregion

        #region Public Property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddWalletTransactionID { get => _addWalletTransactionID; set => _addWalletTransactionID = value; }
        public Guid UserID { get => _userID; set => _userID = value; }
        public Guid WalletID { get => _WalletID; set => _WalletID = value; }
        public Guid FundRequestID { get => _FundRequestID; set => _FundRequestID = value; }
        [StringLength(128)]
        public string TransactionNumber { get => _transactionNumber; set => _transactionNumber = value; }
        [StringLength(128)]
        public string TrackingID { get => _trackingID; set => _trackingID = value; }
        public DateTime TransactionDate { get => _transactionDate; set => _transactionDate = value; }
        [StringLength(128)]
        public string BankRefNo { get => _bankRefNo; set => _bankRefNo = value; }
        [StringLength(128)]
        public string PaymentMode { get => _paymentMode; set => _paymentMode = value; }
        [StringLength(128)]
        public string Description { get => _description; set => _description = value; }
        [StringLength(128)]
        public string Status { get => _status; set => _status = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        [StringLength(16)]
        public string Currency { get => _currency; set => _currency = value; }
        public string TransactionType { get => _transactionType; set => _transactionType = value; }
        [StringLength(128)]
        public string Remark { get => _remark; set => _remark = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
        public Guid CreatedByID { get => _createdByID; set => _createdByID = value; }
        public Guid ModifiedByID { get => _modifiedByID; set => _modifiedByID = value; }
        #endregion
    }
}
