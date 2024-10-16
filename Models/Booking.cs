using Microsoft.EntityFrameworkCore;
namespace ParkNow.Models;

public class Booking {
    public enum Statuses
    {
        Active,
        Completed,
        Cancelled
    }
    public int BookingId {get; set;}
    public int PaymentId {get; set;}
    public int UserId {get; set;}
    public required string CarparkId {get; set;}

    public required DateTime? StartTime {get; set;}
    public required DateTime? EndTime {get; set;}
    public required DateTime BookingTime {get; set;}
    public required decimal Cost {get; set;}
    public required Statuses Status {get; set;}
}