using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using System.Collections.Generic;
using BankAPI.Services;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferHistoryModelsController : ControllerBase
    {
        private readonly BankContext _context;

        public TransferHistoryModelsController(BankContext context)
        {
            _context = context;
        }

        // GET: api/TransferHistory
        [HttpGet("GetTransferHistory")]  //Get by account number
        public async Task<List<TransferHistory>> GetTransferHistory(string accountNumber)
        {
            return await _context.TransferHistory.Where(a => a.AccountNumber.Equals(accountNumber)).ToListAsync();
        }
    }
}
