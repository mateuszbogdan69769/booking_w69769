using Domain.Roots.Guests;

namespace ApiApplication.DTOs;

public class GuestDto
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public List<BookingDto>? Bookings { get; set; }

    public static GuestDto Map(Guest guest, bool mapBookings = false)
    {
        return new GuestDto()
        {
            Name = guest.Name,
            Surname = guest.Surname,
            Bookings = mapBookings && guest.Bookings != null ? guest.Bookings.Select(BookingDto.Map).ToList() : null
        };
    }
}