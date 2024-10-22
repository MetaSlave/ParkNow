/*
This class implements the Voucher entity with the attributes
VoucherId, UserId, Amount, Issue, Expiry
*/
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ParkNow.Models;
public class Voucher
{
    public required int VoucherId {get; set;}
    
    [ForeignKey("UserId")]
    public required User User {get; set;}
    [Precision(18, 2)]
    public decimal Amount {get; set;}
    public DateTime Issue {get; set;}
    public DateTime Expiry {get; set;}
}
