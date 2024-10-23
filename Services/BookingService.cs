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
    public async Task<Booking> GetBooking(int BookingId) {
        return await _context.Bookings.Where(b => b.BookingId == BookingId).FirstOrDefaultAsync();
    }

    public async Task<bool> CreateBooking(Booking booking) {
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
    public async Task<bool> UpdateBooking(Booking booking) {
       try {
            // Add Booking
            Booking? db_Booking = await _context.Bookings.Where(b => b.BookingId == booking.BookingId).FirstOrDefaultAsync();
            if (db_Booking == null) {
                return false;
            }
            db_Booking.StartTime = booking.StartTime;
            db_Booking.EndTime= booking.EndTime;
            await _context.SaveChangesAsync();
       }
       catch {
            return false;
       }
        return true;
    }
    public async Task<bool> DeleteBooking(int BookingId) {
        try {
            // Delete Booking
            Booking? db_Booking = await _context.Bookings.Where(b => b.BookingId == BookingId).FirstOrDefaultAsync();
            if (db_Booking == null) {
                return false;
            }
            _context.Remove(db_Booking);
            await _context.SaveChangesAsync();
       }
       catch {
            return false;
       }
        return true;
    }

    public async Task<Decimal>? CalculatePrice(DateTime start, DateTime end, Carpark carpark) {
        return 5.00M;
    }
}
