namespace Domain.Roots.Accounts.Services;

public interface IAccountService
{
    Task<Account?> GetAccountByUsername(string userName);

    Task AddAccount(string name, string username, string password);

    Task<bool> Login(string userName, string password);
}
