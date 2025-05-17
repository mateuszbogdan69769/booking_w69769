using Domain.Common;
using Domain.Roots.Guests;

namespace Domain.Roots.Bookings;

public class Booking : BasicEntity
{
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public int GuestId { get; protected set; }
    public int PartySize { get; protected set; }
    public string Note { get; protected set; }

    public virtual Guest Guest { get; protected set; } = null!;

    private Booking() { }

    public Booking(DateTime startDate, DateTime endDate, Guest guest, int partySize, string note)
    {
        StartDate = startDate;
        EndDate = endDate;
        GuestId = guest.Id;
        Guest = guest;
        PartySize = partySize;
        Note = note;
    }

    public void Update(DateTime startDate, DateTime endDate, int partySize, string note)
    {
        StartDate = startDate;
        EndDate = endDate;
        PartySize = partySize;
        Note = note;
    }
}

