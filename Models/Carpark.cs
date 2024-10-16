namespace ParkNow.Models;

// https://data.gov.sg/datasets/d_23f946fa557947f93a8043bbef41dd09/view
public class Carpark {
    public required string CarparkId {get; set;}
    public required string Address {get; set;}
    public required string XCord {get; set;}
    public required string YCord {get; set;}
    public required string Type {get; set;}
    public required string SystemType {get; set;}
    public required string ShortTermParkingType {get; set;}
    public required string FreeParking {get; set;}
    public required bool NightParking {get; set;}
    public required bool CentralCharge {get; set;}
    
    // To be filled in on api call
    public int? TotalLots {get; set;}
    public int? LotsAvailable {get; set;}
    
    // Bottom Might Not Need
    public required double GantryHeight {get; set;}
    public required bool CarparkBasement {get; set;}
}