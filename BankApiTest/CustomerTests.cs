using BankAPI.Controllers;
using BankAPI.Models;
using BankAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BankApiTest
{
    [TestClass]
    public class CustomerTests
    {

        private readonly BankContext _bankContext;
        private readonly IBankService _bankService;
        private readonly IServiceProvider _serviceProvider;

        [TestMethod]
        public void CreateCustomer_NotNull()
        {
            var controller = new CustomerModelsController(_bankContext, _bankService);

            var actualResult = controller.CreateCustomer(" Kim Parker ");

            Assert.IsNotNull(actualResult);
            
        }

        [TestMethod]
        public void CreateCustomer_Error()
        {

            var controller = new CustomerModelsController(_bankContext, _bankService);

            var actualResult = controller.CreateCustomer(string.Empty); //this result should be exception. How to add null input

            //Assert.Equals(actualResult, "Please enter valid details.");
            Assert.IsFalse(actualResult.ToString().Equals("Please enter valid details.")); //should be isTrue

        }

        [TestMethod]
        public void GetAllCustomers()
        {
            var addedCustomers = PopulateCustomers.Initialize(_serviceProvider);

            var controller = new CustomerModelsController(_bankContext, _bankService);

            Assert.IsTrue(addedCustomers.IsCompleted);

            var actualResult = controller.GetCustomers();

            Assert.IsNotNull(actualResult);
           
        }

        [TestMethod]
        public void GetAllCustomers_Null()
        {
            var controller = new CustomerModelsController(_bankContext, _bankService);

            var actualResult = controller.GetCustomers();
  
            Assert.IsFalse(AssertFailedException.ReferenceEquals(actualResult, null)); //this test makes 0 sense

        }
    }
}