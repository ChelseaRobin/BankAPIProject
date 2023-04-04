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
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public string Message { get; set; }
        public string DateTimeStamp{ get; set; }
    }
}