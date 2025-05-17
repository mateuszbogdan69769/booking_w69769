using Domain.Roots.Bookings;

namespace ApiApplication.DTOs;

public class BookingDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PartySize { get; set; }
    public string Note { get; set; } = string.Empty;
    public GuestDto Guest { get; set; } = null!;

    public static BookingDto Map(Booking booking)
    {
        return new BookingDto()
        {
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            PartySize = booking.PartySize,
            Note = booking.Note,
            Guest = GuestDto.Map(booking.Guest)
        };
    }
}