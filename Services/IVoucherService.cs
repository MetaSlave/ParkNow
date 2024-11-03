using ParkNow.Models;
namespace ParkNow.Services;

public interface IVoucherService
{
    // CRUD
    Task<bool> CreateVoucher(Voucher voucher);
}
