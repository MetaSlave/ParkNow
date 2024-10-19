/*
This class implements the Voucher entity with the attributes
VoucherId, UserId, Amount, Issue, Expiry
*/
using System.ComponentModel.DataAnnotations.Schema;
namespace ParkNow.Models;
public class Voucher
{
    public required int VoucherId {get; set;}
    
    [ForeignKey("UserId")]
    public required User User {get; set;}
    public decimal Amount {get; set;}
    public DateTime Issue {get; set;}
    public DateTime Expiry {get; set;}
}
