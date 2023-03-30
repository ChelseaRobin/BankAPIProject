using System.ComponentModel.DataAnnotations;

namespace BankAPI.ViewModels
{
    public class AccountModel
    {
        [Key]
        //[ConcurrencyCheck] //do we need this?
        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }
        public int Balance { get; set; } //inital deposit

        public virtual CustomerModel Customer { get; set; }
        //public virtual ICollection<TransactionModel> TransactionsList { get; set; }

    }
}
