using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using BankAPI.Services;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountModelsController : ControllerBase
    {
        private readonly BankContext _context;

        private readonly IBankService _methods;

        public AccountModelsController(BankContext context, IBankService methods)
        {
            _context = context;
            _methods = methods;
        }

        // GET: api/AccountModels
        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            //if (_context.Accounts == null)
            //{
            //    return NotFound();
            //}
            return await _context.Accounts.Include(c => c.Customer).ToListAsync(); //incluse customer that have the same name
        }

        // GET: api/AccountModels
        [HttpGet("GetBalance")] //gets Balance of account by account number
        public async Task<string> GetBalance(string accountNum)
        {
            var fullAccount = (await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber.Equals(accountNum.AsEnumerable())));

            var account = " ";
            if (fullAccount == null)
            {
                return account = "Account not Found)";
            }

            return account = fullAccount.Balance.ToString();
        }

        // PUT: api/AccountsModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("TransferFunds")] //Updates balances
        public async Task<string> TransferFunds(int Amount, string senderAccNum, string recipientAccNumm)
        {
            var update = await _methods.TransferFunds(Amount, senderAccNum, recipientAccNumm);

            return update;
        }

        // POST: api/AccountModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateNewAccount")]//Find customer and creates new account and adds to account list
        public async Task<string> CreateAccount(int CustomerId, int Deposit)
        {
            if (!CustomerExists(CustomerId))
            {
                return "Customer Id: " + CustomerId + ", does not exist. Please create a new customer or enter valid customer id";
            }

            if (Deposit <= 0)
            {
                return "Deposit ammount cannot be null or a negative value.";
            }

            var AccountNum = await _methods.CreateAccount(CustomerId, Deposit);

            return AccountNum;
        }



        // DELETE: api/AccountModels
        [HttpDelete("DeleteAccount")]
        public async Task<string> DeleteAccount(string AccountNumber)
        {
            return await _methods.DeleteAccount(AccountNumber);
        }

        private bool CustomerExists(int id) 
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
