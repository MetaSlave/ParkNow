using ParkNow.Models;
namespace ParkNow.Services;
/*
This interface implements the methods of the Booking entity
GetUserBookings, CreateNewBooking, CalculatePrice
*/
public interface IBookingService
{
    Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark);

    // CRUD
    Task<bool> CreateBooking(Booking booking);
    Task<List<Booking>> GetUserBookings(string username);
    Task<Booking> GetBooking(int BookingId);
    Task<bool> UpdateBooking(Booking booking);
    Task<bool> DeleteBooking(int BookingId);
    
}
