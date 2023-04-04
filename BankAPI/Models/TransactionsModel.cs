using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class TransactionsModel
    {
        [Key]
        public int id { get; set; }
        public int Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Message { get; set; }
        public string DateTimeStamp{ get; set; }
    }
}