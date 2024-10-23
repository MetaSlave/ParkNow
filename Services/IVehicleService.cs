using ParkNow.Models;

namespace ParkNow.Services;
/*
This interface implements the methods of the Vehicle entity
GetUserVehicles, GetVehicle, CreateNewVehicle, EditExistingVehicle
*/
public interface IVehicleService
{
    Task<List<Vehicle>> GetUserVehicles(string username);
    Task<Vehicle> GetVehicle(string licenseplate);
    Task<bool> CreateNewVehicle(Vehicle vehicle);
    Task<bool> EditExistingVehicle(Vehicle vehicle);
    Task<bool> DeleteExistingVehicle(int VehicleId);
    
}
