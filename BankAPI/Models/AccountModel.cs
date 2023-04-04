using BankAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class AccountModel
    {
        [Key]
        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }
        public int Balance { get; set; } //inital deposit

        public virtual CustomerModel Customer { get; set; }
        public virtual ICollection<TransferHistory> TransactionsList { get; set; }

    }
}
