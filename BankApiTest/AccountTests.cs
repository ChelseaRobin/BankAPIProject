using BankAPI.Controllers;
using BankAPI.Models;
using BankAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApiTest
{
    [TestClass]
    public class AccountTests
    {

        private readonly BankContext _bankContext;
        private readonly IBankService _bankService;

        [TestMethod]
        public void CreateAccount_NotNull()
        {
            var Customerscontroller = new CustomerModelsController(_bankContext, _bankService);

            var createCustomer = Customerscontroller.CreateCustomer("Kim Parker"); 

            var controller = new AccountModelsController(_bankContext, _bankService);

            var actualResult = controller.CreateAccount(1, 200);

            Assert.IsNotNull(actualResult);

        }

        [TestMethod]
        public void GetBalance()
        {
            var Customerscontroller = new CustomerModelsController(_bankContext, _bankService);

            var createCustomer = Customerscontroller.CreateCustomer("Kim Parker");

            var controller = new AccountModelsController(_bankContext, _bankService);

            var createAccount = controller.CreateAccount(1, 200);

            var actualResult = controller.GetBalance(createAccount.ToString());

            Assert.IsNotNull(actualResult);

        }
    }
}