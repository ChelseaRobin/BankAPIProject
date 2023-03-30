namespace BankAPI.Services
{
    public interface IBankService
    {
        Task<string> CreateAccount(int CustomerId, int Deposit);

        Task<string> CreateCustomer(string CustomerName);

        Task<string> TransferFunds(int Amount, string senderAccNum, string recipientAccNum);
    }
}
