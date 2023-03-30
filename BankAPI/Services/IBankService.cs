namespace BankAPI.Services
{
    public interface IBankService
    {
        Task<string> CreateAccount(int CustomerId, int Deposit);

        Task<string> CreateCustomer(string CustomerName);

        Task<string> TransferAmount(int Amount, string senderAccNum, string recipientAccNum);
    }
}
