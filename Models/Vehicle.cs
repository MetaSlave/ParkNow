namespace ParkNow.Models;

public class Vehicle {
    public enum CarTypes
    {
        Private,
        Commercial,
        SpecialPurpose,
        Electric,
        PublicService
    }
    public int VehicleId {get; set;}
    public int UserId {get; set;}
    public required string LicensePlate {get; set;}
    public string? Model {get; set;}
    public required CarTypes CarType {get; set;}
}