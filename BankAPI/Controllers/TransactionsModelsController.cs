using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

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
        public async Task<ActionResult<TransactionsModel>> GetTransactionsModel(string accountNumber)
        {
          if (_context.TransactionsModel == null)
          {
              return NotFound();
          }
            var transactions = await _context.TransactionsModel.FirstOrDefaultAsync(a => a.AccountNumber.Equals(accountNumber));

            if (transactions == null)
            {
                return NotFound();
            }

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

        private bool TransactionsModelExists(int id)
        {
            return (_context.TransactionsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
