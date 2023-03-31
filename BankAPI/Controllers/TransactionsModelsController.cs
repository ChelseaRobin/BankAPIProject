using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/TransactionsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionsModel>>> GetTransactionsModel()
        {
          if (_context.TransactionsModel == null)
          {
              return NotFound();
          }
            return await _context.TransactionsModel.ToListAsync();
        }

        // GET: api/TransactionsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionsModel>> GetTransactionsModel(int id)
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

            return transactionsModel;
        }

        // PUT: api/TransactionsModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionsModel(int id, TransactionsModel transactionsModel)
        {
            if (id != transactionsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TransactionsModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionsModel>> PostTransactionsModel(TransactionsModel transactionsModel)
        {
          if (_context.TransactionsModel == null)
          {
              return Problem("Entity set 'BankContext.TransactionsModel'  is null.");
          }
            _context.TransactionsModel.Add(transactionsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionsModel", new { id = transactionsModel.Id }, transactionsModel);
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
