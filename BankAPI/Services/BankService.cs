﻿using BankAPI.Models;
using BankAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Services;

public class BankService : IBankService
{

    private readonly BankContext _bankContext;

    public BankService(BankContext bankContext)
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

   
    public async Task<string> TransferAmount(int Amount, string senderAccNum, string recipientAccNum)
    {
        var account = _bankContext.Accounts;

        var NewBalanceR = 0;

        var NewBalanceS = 0;

        var recipient = await account.FirstOrDefaultAsync(a => a.AccountNumber.Equals(recipientAccNum));

        var sender = await account.FirstOrDefaultAsync(a => a.AccountNumber.Equals(senderAccNum));

        if (recipient != null)
        {
            NewBalanceR = UpdateRecipient(Amount, recipient.Balance);
            recipient.Balance = NewBalanceR;
        }

        if (sender != null)
        {
            NewBalanceS = UpdateSender(Amount, sender.Balance);
            sender.Balance = NewBalanceS;
        }

        _bankContext.Update(recipient);
        _bankContext.Update(sender);

        await _bankContext.SaveChangesAsync();

        return "Transfer success!";

    }

    private int UpdateRecipient(int Amount, int Recipient)
    {
        var NewBalance = Recipient + Amount;
        return NewBalance;
    }

    private int UpdateSender(int Amount, int Sender)
    {
        var NewBalance = Sender - Amount;
        return NewBalance;
    }

}