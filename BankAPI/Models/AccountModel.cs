using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class AccountModel
    {
        [Key]
        [ConcurrencyCheck] //do we need this?
        public string AccountNumber { get; set; } = Guid.NewGuid().ToString(); 

        public int CustomerId { get; set; } 
        public int Amount { get; set; } //inital deposit

        public virtual CustomerModel Customer { get; set; }
        //public virtual ICollection<TransactionModel> TransactionsList { get; set; }

    }
}
