namespace ParkNow.Models;
public class Voucher
{
    public required int VoucherId {get; set;}
    public int UserId {get; set;}
    public double Amount {get; set;}
    public DateTime Issue {get; set;}
    public DateTime Expiry {get; set;}
}
