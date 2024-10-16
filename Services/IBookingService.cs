using ParkNow.Models;
namespace ParkNow.Services;

public interface IBookingService
{
    Task<List<Booking>> GetUserBookings(string username);

    Task<bool> CreateNewBooking(Booking booking);
    
    Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark);
}
