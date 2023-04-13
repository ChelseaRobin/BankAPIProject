using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Services
{
    public interface IBankService
    {
        Task<string> CreateAccount(int CustomerId, int Deposit);

        Task<string> CreateCustomer(string CustomerName);

        Task<string> TransferFunds(int Amount, string senderAccNum, string recipientAccNum);

        Task AddTransaction(int amount, int balance, string accNum, string msg);

        Task<string> DeleteCustomer(int id);
        Task<string> DeleteAccount(string AccountNumber);
        Task<string> DeleteTransferHistory(string accountNumber);

    }
}
