using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartWallet.DatabaseEntity.Wallet
{
    [Table("Wallets")]
    public class Wallets
    {
        #region Private Fields
        private Guid _walletID = Guid.NewGuid();
        private Guid _userID;
        private decimal _walletBalance = 0;
        private int _status;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private Guid _createdByID;
        private Guid _modifiedByID;
        #endregion

        #region Public Property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WalletID { get => _walletID; set => _walletID = value; }

        [ForeignKey("User")]
        public Guid UserID { get => _userID; set => _userID = value; }
        // public User user { get; set; }

        [Required]
        public decimal WalletBalance { get => _walletBalance; set => _walletBalance = value; }

        [Required]
        public int Status { get => _status; set => _status = value; }

        [Required]
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }

        [Required]
        public Guid CreatedBy { get => _createdByID; set => _createdByID = value; }

        [Required]
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }

        [Required]
        public Guid ModifiedBy { get => _modifiedByID; set => _modifiedByID = value; }

        #endregion
    }
}
