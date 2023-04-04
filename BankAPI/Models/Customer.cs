using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } //customers id
        public string Name { get; set; } //name of customer
        public virtual ICollection<Account> AccountsList { get; set; }

    }
}
