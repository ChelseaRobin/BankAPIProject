using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class TransferHistory
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string AccountNumber { get; set; }
        
        public int Amount { get; set; }
        public string Message { get; set; }

        public int CurrentBalance { get; set; }
        public string DateTimeStamp{ get; set; }
    }
}