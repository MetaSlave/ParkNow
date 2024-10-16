using ParkNow.Models;

namespace ParkNow.Services;

public interface ICarparkService
{
    Task<List<Carpark>> GetAllCarparks();
    Task<Carpark> GetCarpark(string carparkid);
}
