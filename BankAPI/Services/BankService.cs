using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BankAPI.Services;

public class BankService : IBankService
{

    private readonly BankContext _bankContext;

    public BankService(BankContext bankContext)
    {
        _bankContext = bankContext;
    }

    public async Task AddTransaction(int ammount, int balance, string accNum, string msg)
    {

        var transaction = new TransferHistory()
        {
            CurrentBalance = balance,
            AccountNumber = accNum,
            Message = msg,
            Amount = ammount,
            DateTimeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
        };
        

        var accounts = _bankContext.Accounts;
        foreach (var account in accounts)
        {
            if (account.AccountNumber == accNum)
            {
                if (account.TransferHistory == null)
                {
                    account.TransferHistory = new List<TransferHistory>
                    {
                        transaction,
                    };
                }
                else
                {
                    account.TransferHistory.Add(transaction);
                }
                _bankContext.Update(account);

                await _bankContext.SaveChangesAsync();
                break;
            }
        }
     
    }

    public async Task<string> CreateAccount(int CustomerId, int Deposit)
    {
        var account = new List<Account> 
            {
                new Account()
                {
                    AccountNumber = Guid.NewGuid().ToString(),
                    CustomerId = CustomerId,
                    Balance = Deposit,
                   
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

    public async Task<string> DeleteAccount(string AccountNumber)
    {
        var accounts = _bankContext.Accounts;


        if (accounts == null)
        {
            return "Not Found";
        }

        foreach (var account in accounts)
        {
            if (account.AccountNumber == AccountNumber)
            {
                _bankContext.Accounts.Remove(account);
                await DeleteTransferHistory(AccountNumber); //deletes account transfer history when the account is deleted
                await _bankContext.SaveChangesAsync();
            }
        }
        return "Account successfully deleted.";
    }

    public async Task<string> CreateCustomer(string CustomerName) 
    {
        _bankContext.Customers.Add(new Customer() //create new customer
        {
            Name = CustomerName, //adds name to create customer
        });

        await _bankContext.SaveChangesAsync();

        var customerId = _bankContext.Customers.Count();

        return customerId.ToJson(); 

    }

    public async Task<string> DeleteCustomer(int CustomerId)
    {
        var customer = await _bankContext.Customers.FindAsync(CustomerId);

        if (customer == null)
        {
            return "Not Found";
        }

        var accounts = _bankContext.Accounts;

        foreach (var account in accounts) 
        {
            if (account.CustomerId == CustomerId)
            {
                await DeleteAccount(account.AccountNumber);
                _bankContext.Customers.RemoveRange(customer);
                await _bankContext.SaveChangesAsync();
            }
        }
        return "Customer deleted.";
    }

    public async Task<string> DeleteTransferHistory(string accountNumber)
    {
        var transferHistory = _bankContext.TransferHistory;
        if (transferHistory == null)
        {
            return "Not Found";
        }

        foreach (var transfer in transferHistory)
        {
            if (transfer.AccountNumber == accountNumber)
            {
                _bankContext.TransferHistory.RemoveRange(transfer);
                await _bankContext.SaveChangesAsync();
            }
        }
        return "Transfer History successfully deleted for account: " + accountNumber;
    }

    public async Task<string> TransferFunds(int Amount, string senderAccNum, string recipientAccNum)
    {
        var account = _bankContext.Accounts;

        var NewBalanceR = 0;

        var NewBalanceS = 0;

        var recipient = await account.FirstOrDefaultAsync(a => a.AccountNumber.Equals(recipientAccNum)); //Gets account that matches recipient's account number

        var sender = await account.FirstOrDefaultAsync(a => a.AccountNumber.Equals(senderAccNum)); //Gets account that matches sender's account number

        if (recipient != null & sender != null)
        {
            NewBalanceR = RecipientCalcu(Amount, recipient.Balance);
            NewBalanceS = SenderCalcu(Amount, sender.Balance);

            recipient.Balance = NewBalanceR;
            sender.Balance = NewBalanceS;
        }

        await _bankContext.SaveChangesAsync();

        await AddTransaction(Amount, recipient.Balance, recipientAccNum, "Funds received from "+senderAccNum);
        await AddTransaction(Amount, sender.Balance, senderAccNum, "Funds sent to "+recipientAccNum);

        return "Transfer success!";

    }


    /*private methods only used by public methods in this folder */
    private int RecipientCalcu(int Amount, int Recipient)
    {
        var NewBalance = Recipient + Amount;
        return NewBalance;
    }

    private int SenderCalcu(int Amount, int Sender)
    {
        var NewBalance = Sender - Amount;
        return NewBalance;
    }
}
