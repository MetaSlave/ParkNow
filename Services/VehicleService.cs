using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using ParkNow.Data;
using ParkNow.Migrations;
using ParkNow.Models;
namespace ParkNow.Services;

public class VehicleService : IVehicleService
{
    // Get Database Context and Constructor to include context
    private readonly ILogger<VehicleService> _logger;
    private readonly AppDbContext _context;
    public VehicleService(AppDbContext context, ILogger<VehicleService> logger) {
        _context = context;
        _logger = logger;
    }
    public async Task<List<Vehicle>> GetUserVehicles(string username) {
        int userid = await _context.Users.Where(u => u.Username == username).Select(u => u.UserId).FirstOrDefaultAsync();
        return await _context.Vehicles.Where(v => v.UserId == userid).ToListAsync();
    }
    public async Task<Vehicle> GetVehicle(string licenseplate) {
        return await _context.Vehicles.Where(v => v.LicensePlate == licenseplate).FirstOrDefaultAsync();
    }
    public async Task<bool> CreateNewVehicle(Vehicle vehicle) {
       try {
            // Add vehicle
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return true;
       }
       catch {
            return false;
       }
    }
    public async Task<bool> EditExistingVehicle(Vehicle vehicle) {
       try {
            // Add vehicle
            Vehicle? db_vehicle = await _context.Vehicles.Where(v => v.VehicleId == vehicle.VehicleId).FirstOrDefaultAsync();
            if (db_vehicle == null) {
                return false;
            }
            db_vehicle.LicensePlate = vehicle.LicensePlate;
            db_vehicle.Model = vehicle.Model;
            db_vehicle.CarType = vehicle.CarType;
            await _context.SaveChangesAsync();
       }
       catch {
            return false;
       }
        return true;
    }
}
