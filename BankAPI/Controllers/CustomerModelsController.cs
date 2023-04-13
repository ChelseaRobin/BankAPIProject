using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using BankAPI.Services;
using NuGet.Protocol;
using System.Text.RegularExpressions;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerModelsController : ControllerBase
    {
        private readonly BankContext _context;

        private readonly IBankService _methods;

        public CustomerModelsController(BankContext context, IBankService methods)
        {
            _context = context;
            _methods = methods;
        }

        // GET: api/CustomerModels
        [HttpGet ("GetAllCustomers")]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.Include(c => c.AccountsList).ToListAsync();
        }


        // POST: api/CustomerModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("CreateNewCustomer")]
        public async Task<string> CreateCustomer(string CustomerName)
        {
            return await _methods.CreateCustomer(CustomerName);
        }

        //DELETE: api/CustomerModels/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCustomerModel(int id)
        {
            return await _methods.DeleteCustomer(id);
        }
    }
}
