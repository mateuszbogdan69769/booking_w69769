using Domain.Common;

namespace Domain.Roots.Accounts;
public class Account : BasicEntity
{
    public string Name { get; protected set; } = null!;
    public string Username { get; protected set; } = null!;
    public string PasswordHash { get; protected set; } = null!;

    private Account() { }

    public Account(string name, string username, string passwordHash)
    {
        Name = name;
        Username = username;
        PasswordHash = passwordHash;
    }
}
