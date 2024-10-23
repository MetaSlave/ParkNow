using ParkNow.Models;

namespace ParkNow.Services;
/*
This interface implements the methods of the Vehicle entity
GetUserVehicles, GetVehicle, CreateNewVehicle, EditExistingVehicle
*/
public interface IVehicleService
{
    // CRUD
    Task<bool> CreateVehicle(Vehicle vehicle);
    Task<Vehicle> GetVehicle(string licenseplate);
    Task<List<Vehicle>> GetUserVehicles(string username);
    Task<bool> UpdateVehicle(Vehicle vehicle);
    Task<bool> DeleteVehicle(int VehicleId);
    
}
