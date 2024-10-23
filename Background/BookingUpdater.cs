using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ParkNow.Data;
using ParkNow.Models;

namespace ParkNow.Background;

// Updates Booking Statuses
public class BookingUpdater : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<BookingUpdater> _logger;

    public BookingUpdater(IServiceScopeFactory serviceScopeFactory, ILogger<BookingUpdater> logger)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await UpdateBookingStatus(context);
                // Every 1 min call
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
    private async Task UpdateBookingStatus(AppDbContext context) {
        // Only get Non Cancelled Bookings
        List<Booking> all_bookings = await context.Bookings.Where(b => b.Status != Booking.Statuses.Cancelled).ToListAsync();
        foreach (Booking book in all_bookings) {
            if (book.EndTime <= DateTime.Now) {
                book.Status = Booking.Statuses.Completed;
            }
        }
        await context.SaveChangesAsync();
    }
}

