using Domain.Enums;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Domain.Helpers;

public class PasswordService
{
    private readonly string _salt;
    private const int Iterations = 10000;
    private const int HashLength = 32;

    public PasswordService(IConfiguration configuration)
    {
        _salt = configuration[ConfigConsts.PasswordHashSecret] ?? throw new InvalidOperationException("PasswordHashSecret is not configured.");
    }

    public bool VerifyPassword(string inputPassword, string storedHashedPassword)
    {
        return CreatePasswordHash(inputPassword) == storedHashedPassword;
    }

    public string CreatePasswordHash(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);

        using (var sha256 = new SHA256Managed())
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashLength);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
