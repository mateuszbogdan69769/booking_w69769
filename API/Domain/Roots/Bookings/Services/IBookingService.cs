namespace Domain.Roots.Bookings.Services;

public interface IBookingService
{
    Task<List<Booking>> GetAllBookings();

    Task<List<Booking>> GetFilteredBookings(string? searchQuery, DateTime dateFrom, DateTime dateTo);

    Task<int> AddBooking(Booking booking);

    Task<Booking?> GetBookingById(int id);

    Task UpdateBooking(int id, DateTime startDate, DateTime endDate, int partySize, string note);

    Task DeleteReservationById(int id);
}
