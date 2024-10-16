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
        int userid = await _context.Users.Where(u => u.Username == username).Select(u => u.UserId).FirstOrDefaultAsync();
        return await _context.Bookings.Where(v => v.UserId == userid).ToListAsync();
    }

    public async Task<bool> CreateNewBooking(Booking booking) {
       try {
            // Add vehicle
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return true;
       }
       catch {
            return false;
       }
    }

    public async Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark) {
        return 5.00M;
    }
}
