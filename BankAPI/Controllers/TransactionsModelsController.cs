using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using System.Collections.Generic;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsModelsController : ControllerBase
    {
        private readonly BankContext _context;

        public TransactionsModelsController(BankContext context)
        {
            _context = context;
        }

        // GET: api/TransactionsModels/5
        [HttpGet("GetByAccountNumber")]  //Get by account number
        public async Task<List<TransactionsModel>> GetTransactionsModel(string accountNumber)
        {
            var transactions = await _context.TransactionsModel.Where(a => a.AccountNumber.Equals(accountNumber)).ToListAsync();

            return transactions;
        }

        // DELETE: api/TransactionsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionsModel(int id)
        {
            if (_context.TransactionsModel == null)
            {
                return NotFound();
            }
            var transactionsModel = await _context.TransactionsModel.FindAsync(id);
            if (transactionsModel == null)
            {
                return NotFound();
            }

            _context.TransactionsModel.Remove(transactionsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool TransactionsModelExists(int id)
        //{
        //    return (_context.TransactionsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
