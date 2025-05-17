using ApiApplication.Bookings.Commands;
using ApiApplication.DTOs;
using ApiApplication.Queries.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers;

[Tags("Booking")]
public class BookingController : BasicApiController
{
    [HttpGet]
    public async Task<ActionResult<List<BookingDto>>> GetBookings(GetBookingsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult> CreateBooking(CreateBookingCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBooking(UpdateBookingCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBooking(int id)
    {
        await Mediator.Send(new DeleteBookingCommand(id));
        return NoContent();
    }
}