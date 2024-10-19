using ParkNow.Models;

namespace ParkNow.Services;
/*
This interface implements the methods of the Carpark entity
GetAllCarparks, GetCarpark
*/
public interface ICarparkService
{
    Task<List<Carpark>> GetAllCarparks();
    Task<Carpark> GetCarpark(string carparkid);
}
