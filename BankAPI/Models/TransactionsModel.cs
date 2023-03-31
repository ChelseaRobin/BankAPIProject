using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class TransactionsModel
    {
        [Key]
        public int Id { get; set; } 
        //add balance
        public string accnum { get; set; }

        //add date and time
    }
}