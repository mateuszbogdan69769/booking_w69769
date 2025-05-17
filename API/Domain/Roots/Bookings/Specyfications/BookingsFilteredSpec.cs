using Ardalis.Specification;

namespace Domain.Roots.Bookings.Specyfications;

internal class BookingsFilteredSpec : Specification<Booking>
{
    public BookingsFilteredSpec(string? searchQuery, DateTime dateFrom, DateTime dateTo)
    {
        Query.Include(x => x.Guest);

        Query.Where(x => x.StartDate >= dateFrom && x.EndDate <= dateTo);

        if (!String.IsNullOrEmpty(searchQuery))
        {
            Query.Where(x => (x.Guest.Name + " " + x.Guest.Surname).ToLower().Trim().Contains(searchQuery.ToLower().Trim()));
        }
    }
}
