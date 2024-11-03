using ParkNow.Models;
using ParkNow.Data;

namespace ParkNow.Services;

public class VoucherService : IVoucherService
{
    // Get Database Context and Constructor to include context
    private readonly ILogger<VoucherService> _logger;
    private readonly AppDbContext _context;
    public VoucherService(AppDbContext context, ILogger<VoucherService> logger) {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateVoucher(Voucher voucher) {
        try {
                // Add Voucher
                await _context.Vouchers.AddAsync(voucher);
                await _context.SaveChangesAsync();
                return true;
        }
        catch (Exception e){
                _logger.LogInformation(e.Message);
                _logger.LogInformation(e.InnerException.Message);
                return false;
        }
        }
}
