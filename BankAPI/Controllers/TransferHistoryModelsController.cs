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
        private readonly IBankService _methods;

        public TransferHistoryModelsController(IBankService methods)
        {
            _methods = methods;
        }

        // GET: api/TransferHistory
        [HttpGet("GetTransferHistory")]  //Get by account number
        public async Task<List<TransferHistory>> GetTransferHistory(string accountNumber)
        {
            return await _methods.GetTransferHistory(accountNumber);
        }
    }
}
