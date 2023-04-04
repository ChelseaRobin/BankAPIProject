﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class TransferHistory
    {
        [Key]
        public int id { get; set; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public string Message { get; set; }
        public string DateTimeStamp{ get; set; }
    }
}