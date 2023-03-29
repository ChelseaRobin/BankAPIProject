using BankAPI.Models;

namespace BankAPI.Services;

public class Methods : IMethods
{

    private readonly BankContext _bankContext;

    public Methods(BankContext bankContext)
    {
        _bankContext = bankContext;
    }

    public async Task<string> CreateAccount(int CustomerId, int Deposit)
    {
        var account = new List<AccountModel> 
            {
                new AccountModel()
                {
                    AccountNumber = Guid.NewGuid().ToString(),
                    CustomerId = CustomerId,
                    Amount = Deposit,
                }
            };

        var customers = _bankContext.Customers; //Get customers

        foreach (var customer in customers)
        {
            if (customer.CustomerId == CustomerId)
            {
                customer.AccountsList = account;
            }
        }

        await _bankContext.SaveChangesAsync();

        var accountNum = account.First().AccountNumber.ToString();

        return accountNum;
    }

        //var result = "New account created." + DateTime.Now.ToString(" {dd/MM/yyyy h:mm tt}");

        //var accnum = string.Empty;
        //var updateAcc = _bankContext.Accounts; //add to transactions list
        //foreach (var account in updateAcc)
        //{
        //    if (account.CustomerId == accountViewModel.CustomerId)
        //    {
        //        var transList = new List<TransactionModel> //add to transactions list
        //        {
        //            new TransactionModel() {AccountNumber = account.AccountNumber, Message = result}
        //        };
        //        account.TransactionsList = transList;
        //    }
        //    accnum = account.AccountNumber.ToString();
        //}

    public async Task<string> CreateCustomer(string CustomerName) //this doesn't work
    {
        _bankContext.Customers.Add(new CustomerModel() //create new customer
        {
            Name = CustomerName, //adds name to create customer
        });

        await _bankContext.SaveChangesAsync();

        var customerId = _bankContext.Customers.Count();

        return customerId.ToString(); //how to return exact customer Id.

    }

   
    public Task<string> TransferAmount(int Amount, string FAccount, string TAccount)
    {
        throw new NotImplementedException();
    }

   
}
