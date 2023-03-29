namespace BankAPI.Services
{
    public interface IMethods
    {
        Task<string> CreateAccount(int CustomerId, int Deposit);

        Task<string> CreateCustomer(string CustomerName);

        Task<string> TransferAmount(int Amount, string FAccount, string TAccount);
    }
}
