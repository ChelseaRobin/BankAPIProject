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

        private readonly IBankService _methods;

        public TransferHistoryModelsController(BankContext context, IBankService methods)
        {
            _context = context;
            _methods = methods;
        }

        // GET: api/TransferHistory
        [HttpGet("GetTransferHistory")]  //Get by account number
        public async Task<List<TransferHistory>> GetTransferHistory(string accountNumber)
        {

            //var transactions = await _context.TransactionsModel.

            //var accounts = (await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber.Equals(accountNum.AsEnumerable())));
            var transactions = await _context.TransferHistory.Where(a => a.AccountNumber.Equals(accountNumber)).ToListAsync();


            return transactions;
        }
    }
}
