using Microsoft.EntityFrameworkCore;
using ParkNow.Data;
using ParkNow.Models;

namespace ParkNow.Services;

public class BookingService : IBookingService
{
    // Get Database Context and Constructor to include context
    private readonly ILogger<BookingService> _logger;
    private readonly AppDbContext _context;
    public BookingService(AppDbContext context, ILogger<BookingService> logger) {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Booking>> GetUserBookings(string username) {
        return await _context.Bookings
        .Include(b => b.Vehicle)
        .Include(b => b.Carpark)
        .Where(v => v.User.Username == username).ToListAsync();
    }

    public async Task<bool> CreateNewBooking(Booking booking) {
       try {
            // Add Booking and Payment
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            Payment temp_pay = new Payment{
                Booking = booking,
                Timestamp = DateTime.Now,
                Amount = booking.Cost,
                Status = Payment.Statuses.Success
            };
            await _context.Payments.AddAsync(temp_pay);
            await _context.SaveChangesAsync();
            return true;
       }
       catch (Exception e){
            _logger.LogInformation(e.Message);
            _logger.LogInformation(e.InnerException.Message);
            return false;
       }
    }

    public async Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark) {
        return 5.00M;
    }
}
