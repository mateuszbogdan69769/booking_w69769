using Domain.Roots.Accounts.Services;
using FluentValidation;
using MediatR;

namespace ApiApplication.Bookings.Commands;

public class LoginCommand : IRequest<bool>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Nazwa użytkownika jest wymagana");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Hasło jest wymagane");
    }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IAccountService _accountService;

    public LoginCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.Login(request.Username, request.Password);
    }
}