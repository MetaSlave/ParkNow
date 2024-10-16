using ParkNow.Models;

namespace ParkNow.Services;

public interface IVehicleService
{
    Task<List<Vehicle>> GetUserVehicles(string username);
    Task<Vehicle> GetVehicle(string licenseplate);
    Task<bool> CreateNewVehicle(Vehicle vehicle);
    Task<bool> EditExistingVehicle(Vehicle vehicle);
    
}
