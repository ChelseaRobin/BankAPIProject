using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using System.Collections.Generic;

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

            //var transactions = await _context.TransactionsModel.

            //var accounts = (await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber.Equals(accountNum.AsEnumerable())));
            var transactions = await _context.TransferHistory.Where(a => a.AccountNumber.Equals(accountNumber)).ToListAsync();


            return transactions;
        }

        //// DELETE: api/TransactionsModels/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTransactionsModel(int id)
        //{
        //    if (_context.TransferHistory == null)
        //    {
        //        return NotFound();
        //    }
        //    var transactionsModel = await _context.TransferHistory.FindAsync(id);
        //    if (transactionsModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TransferHistory.Remove(transactionsModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AccountExists(string accountNumber)
        //{
        //    return (_context.TransferHistory?.Any(e => e.AccountNumber == accountNumber)).GetValueOrDefault();
        //}
    }
}
