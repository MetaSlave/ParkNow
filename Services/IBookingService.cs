using ParkNow.Models;
namespace ParkNow.Services;
/*
This interface implements the methods of the Booking entity
GetUserBookings, CreateNewBooking, CalculatePrice
*/
public interface IBookingService
{
    Task<List<Booking>> GetUserBookings(string username);

    Task<bool> CreateNewBooking(Booking booking);
    
    Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark);
}
