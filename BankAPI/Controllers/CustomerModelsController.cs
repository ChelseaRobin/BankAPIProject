using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using BankAPI.Services;

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
        public async Task<List<CustomerModel>> GetCustomers()
        {
            if (_context.Customers == null)
            {
                throw new Exception("not found");
            }

            return await _context.Customers.Include(c => c.AccountsList).ToListAsync();
        }


        // POST: api/CustomerModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("CreateNewCustomer")]
        public async Task<string> CreateCustomer(string CustomerName)
        {
            if (CustomerName == null)
            {
                throw new Exception("Please enter valid details."); //validation
            }

            return await _methods.CreateCustomer(CustomerName);
        }

        // DELETE: api/CustomerModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerModel(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customerModel = await _context.Customers.FindAsync(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerModelExists(string name) //might reference code at a later stage
        {
            return (_context.Customers?.Any(e => e.Name == name)).GetValueOrDefault();
        }
    }
}
