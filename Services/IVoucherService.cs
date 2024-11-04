using ParkNow.Models;
namespace ParkNow.Services;

public interface IVoucherService
{
    // CRUD
    Task<bool> CreateVoucher(Voucher Voucher);
    Task<List<Voucher>> GetAllVouchers();
    Task<Voucher> GetVoucher(string VoucherId);
    Task<bool> DeleteVoucher(string VoucherId);
    Task<(bool success,decimal amount)> VerifyVoucher(string Username, string VoucherId);
}
