using System.ComponentModel.DataAnnotations;
using Domain.Helpers;
using Domain.Roots.Accounts.Repos;
using Domain.Roots.Accounts.Specyfications;
using Microsoft.Extensions.Configuration;

namespace Domain.Roots.Accounts.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IConfiguration _configuration;

    public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
    {
        _accountRepository = accountRepository;
        _configuration = configuration;
    }

    public async Task AddAccount(string name, string userName, string password)
    {
        var account = await GetAccountByUsername(userName);
        if (account != null)
        {
            throw new ValidationException($"Użytkownik {userName} już istnieje");
        }

        var passwordService = new PasswordService(_configuration);
        var passwordHash = passwordService.CreatePasswordHash(password);
        var newAccount = new Account(name, userName, passwordHash);
        await _accountRepository.AddAsync(newAccount);
    }

    public async Task<Account?> GetAccountByUsername(string userName)
    {
        var spec = new AccountByUsernameSpec(userName);
        return await _accountRepository.FirstOrDefaultAsync(spec);
    }

    public async Task<bool> Login(string userName, string password)
    {
        var account = await GetAccountByUsername(userName);
        if (account is null) return false;

        var passwordService = new PasswordService(_configuration);
        var passwordCorrect = passwordService.VerifyPassword(password, account.PasswordHash);
        if (!passwordCorrect) return false;

        return true;
    }
}
