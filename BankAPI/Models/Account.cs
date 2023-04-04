using BankAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }
        public int Balance { get; set; } //inital deposit

        public virtual Customer Customer { get; set; }
        public virtual ICollection<TransferHistory> TransferHistory { get; set; }

    }
}
