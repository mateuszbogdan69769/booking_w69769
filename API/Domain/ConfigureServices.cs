using Domain.Aggregates.ReservationServices;
using Domain.Aggregates.StatisticsServices;
using Domain.Roots.Accounts.Services;
using Domain.Roots.Bookings.Services;
using Domain.Roots.Guests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class ConfigureServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // Aggregates
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IStatisticService, StatisticService>();

        // Services
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}
