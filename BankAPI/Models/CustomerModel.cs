using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAPI.Models
{
    public class CustomerModel
    {
        [Key] 
        public int CustomerId { get; set; } //customers id
        public string Name { get; set; } //name of customer
        public virtual ICollection<AccountModel> AccountsList { get; set; }

    }
}
