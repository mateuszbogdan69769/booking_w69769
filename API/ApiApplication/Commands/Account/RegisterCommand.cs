using Domain.Roots.Accounts.Services;
using FluentValidation;
using MediatR;

namespace ApiApplication.Bookings.Commands;

public class RegisterCommand : IRequest
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Imię jest wymagane");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Nazwa użytkownika jest wymagana");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Hasło jest wymagane");
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IAccountService _accountService;

    public RegisterCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _accountService.AddAccount(request.Name, request.Username, request.Password);
    }
}