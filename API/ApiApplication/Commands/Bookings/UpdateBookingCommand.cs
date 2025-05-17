using Domain.Roots.Bookings.Services;
using MediatR;

namespace ApiApplication.Bookings.Commands;

public class UpdateBookingCommand : IRequest
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PartySize { get; set; }
    public string Note { get; set; } = string.Empty;
}

public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
{
    private readonly IBookingService _bookingService;

    public UpdateBookingCommandHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.UpdateBooking(request.Id, request.StartDate, request.EndDate, request.PartySize, request.Note);
    }
}