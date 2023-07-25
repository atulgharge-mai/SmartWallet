using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWallet.DatabaseEntity
{
    public class BankAccountModel
    {
        #region Private Fields
        private Guid _bankAccountID;
        private Guid _userID;
        private string _name = "dummy";
        private string _accountnumber = "123";
        private string _ifsc = "122";
        private bool _isPrimary;
        private int _status;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private Guid _createdByID;
        private Guid _modifiedByID;
        #endregion

        #region Public Property
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BankAccountID { get => _bankAccountID; set => _bankAccountID = value; }

        [ForeignKey("User")]
        public Guid UserID { get => _userID; set => _userID = value; }
        // public User user { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get => _name; set => _name = value; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get => _accountnumber; set => _accountnumber = value; }

        [Required]
        [MaxLength(16)]
        public string IFSCCode { get => _ifsc; set => _ifsc = value; }

        [Required]
        public bool IsPrimary { get => _isPrimary; set => _isPrimary = value; }

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
