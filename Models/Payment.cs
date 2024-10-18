namespace ParkNow.Models;
public class Payment {
    public enum Statuses
    {
        Success,
        Failed,
        Refunded,
        Processing,
    }
    public int PaymentId {get; set;}
    public int BookingId {get; set;}
    public int UserId {get; set;}
    public required decimal Amount {get; set;}
    public required DateTime Timestamp {get; set;}
    public required Statuses Status {get; set;}
}