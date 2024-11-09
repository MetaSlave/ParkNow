# Documentation

## Table of Contents
  - [BookingService](documentation/BookingService.md)
  - [CarparkService](documentation/CarparkService.md)
  - [UserService](documentation/UserService.md)
  - [VehicleService](documentation/VehicleService.md)
  - [VoucherService](documentation/VoucherService.md)
 
# CarparkService

> See complete implementation at `ParkNow.Services.CarparkService`
> 
The `CarparkService` class provides read-only methods to access carpark information within the ParkNow system. This service specifically handles retrieval operations for carpark data.

## CRUD Operations

### GetAllCarparks
```csharp
Task<List<Carpark>> GetAllCarparks()
```
Retrieves all available carparks that allow short-term parking.

**Returns:**
- `Task<List<Carpark>>`: List of all carparks with ShortTermParking enabled
- Returns an empty list if no carparks are found

### GetCarpark
```csharp
Task<Carpark> GetCarpark(string carparkId)
```
Retrieves a specific carpark by its identifier.

**Parameters:**
- `carparkId` (string): The unique identifier of the carpark to retrieve

**Returns:**
- `Task<Carpark>`: The requested carpark entity
- Returns null if no carpark is found with the specified ID

## Notes
- This service is read-only and does not provide methods for creating, updating, or deleting carparks
- The GetAllCarparks method specifically excludes carparks where ShortTermParking is set to NO
- All operations are asynchronous and return Task objects

# UserService

> See complete implementation at `ParkNow.Services.UserService`

The `UserService` class provides methods to manage user operations within the ParkNow system. It includes user management operations such as registration, authentication, and profile updates.

## CRUD Operations

### Register
```csharp
Task<bool> Register(string username, string email, string password)
```
Creates a new user account in the system.

**Parameters:**
- `username` (string): The desired username for the new account
- `email` (string): The email address associated with the account
- `password` (string): The password for the new account

**Returns:**
- `Task<bool>`: True if registration is successful, false otherwise

### GetUser
```csharp
Task<User> GetUser(string username)
```
Retrieves user information for a specific username.

**Parameters:**
- `username` (string): The username to search for

**Returns:**
- `Task<User>`: The requested user entity, or null if not found

### GetUserRole
```csharp
Task<User.Roles> GetUserRole(string username)
```
Retrieves the role assigned to a specific user.

**Parameters:**
- `username` (string): The username to get the role for

**Returns:**
- `Task<User.Roles>`: The user's role, or null if user is not found

### GetAllUsers
```csharp
Task<List<User>> GetAllUsers()
```
Retrieves all users in the system.

**Returns:**
- `Task<List<User>>`: List of all user entities, or empty list if none found

### ChangePassword
```csharp
Task<bool> ChangePassword(string username, string oldPassword, string newPassword)
```
Updates a user's password after verifying their current password.

**Parameters:**
- `username` (string): The username of the account
- `oldPassword` (string): The current password for verification
- `newPassword` (string): The new password to set

**Returns:**
- `Task<bool>`: True if password change is successful, false otherwise

### ChangeEmail
```csharp
Task<bool> ChangeEmail(string username, string email)
```
Updates a user's email address.

**Parameters:**
- `username` (string): The username of the account
- `email` (string): The new email address

**Returns:**
- `Task<bool>`: True if email change is successful, false otherwise

## Authentication Functions

### HashPassword
```csharp
string HashPassword(string password)
```
Creates a secure hash of a password with salt.

**Parameters:**
- `password` (string): The password to hash

**Returns:**
- `string`: The hashed and salted password as a hexadecimal string

### VerifyCredentials
```csharp
Task<bool> VerifyCredentials(string username, string password)
```
Verifies a user's login credentials.

**Parameters:**
- `username` (string): The username to verify
- `password` (string): The password to verify

**Returns:**
- `Task<bool>`: True if credentials are valid, false otherwise

## Notes
- All operations except HashPassword are asynchronous
- Password hashing includes salting for additional security
- User roles are managed through an enumeration defined in the User model
- Email changes do not require password verification, but password changes do

# VehicleService

> See complete implementation at `ParkNow.Services.VehicleService`

The `VehicleService` interface provides methods to manage vehicle operations within the ParkNow system. It handles creation, retrieval, updating, and soft deletion of vehicle records.

## CRUD Operations

### CreateVehicle
```csharp
Task<bool> CreateVehicle(Vehicle vehicle)
```
Creates a new vehicle record associated with a user.

**Parameters:**
- `vehicle` (Vehicle): The vehicle entity to be created

**Returns:**
- `Task<bool>`: True if creation is successful, false otherwise

### GetVehicle
```csharp
Task<Vehicle> GetVehicle(string licenseplate)
```
Retrieves a specific vehicle by its license plate number.

**Parameters:**
- `licenseplate` (string): The license plate number to search for

**Returns:**
- `Task<Vehicle>`: The requested vehicle entity, or null if not found

### GetUserVehicles
```csharp
Task<List<Vehicle>> GetUserVehicles(string username)
```
Retrieves all active (non-deleted) vehicles associated with a specific user.

**Parameters:**
- `username` (string): The username to get vehicles for

**Returns:**
- `Task<List<Vehicle>>`: List of vehicles belonging to the user, or empty list if none found

### UpdateVehicle
```csharp
Task<bool> UpdateVehicle(Vehicle vehicle)
```
Updates an existing vehicle's information (license plate, model, car type).

**Parameters:**
- `vehicle` (Vehicle): The vehicle entity with updated information

**Returns:**
- `Task<bool>`: True if update is successful, false otherwise

### DeleteVehicle
```csharp
Task<bool> DeleteVehicle(int vehicleId)
```
Marks a vehicle as deleted in the system (soft delete).

**Parameters:**
- `vehicleId` (int): The ID of the vehicle to mark as deleted

**Returns:**
- `Task<bool>`: True if deletion is successful, false otherwise

## Notes
- All operations are asynchronous and return Task objects
- Vehicle deletion is implemented as a soft delete (marked as deleted but not removed from database)
- GetUserVehicles only returns vehicles that haven't been marked as deleted
- License plates are used as unique identifiers for vehicle lookup
- Updates to vehicles affect license plate, model, and car type attributes

# VoucherService

> See complete implementation at `ParkNow.Services.VoucherService`

The `VoucherService` interface provides methods to manage voucher operations within the ParkNow system. It handles creation, retrieval, deletion, and verification of voucher records. Note that this service only supports Create, Read, and Delete operations (no updates).

## CRD Operations

### CreateVoucher
```csharp
Task<bool> CreateVoucher(Voucher voucher)
```
Creates a new voucher in the system.

**Parameters:**
- `voucher` (Voucher): The voucher entity to be created

**Returns:**
- `Task<bool>`: True if creation is successful, false otherwise

### GetAllVouchers
```csharp
Task<List<Voucher>> GetAllVouchers()
```
Retrieves all active (non-deleted) vouchers from the system.

**Returns:**
- `Task<List<Voucher>>`: List of all active vouchers, or empty list if none found

### GetVoucher
```csharp
Task<Voucher> GetVoucher(string voucherId)
```
Retrieves a specific voucher by its identifier.

**Parameters:**
- `voucherId` (string): The unique identifier of the voucher to retrieve

**Returns:**
- `Task<Voucher>`: The requested voucher entity, or null if not found

### DeleteVoucher
```csharp
Task<bool> DeleteVoucher(string voucherId)
```
Marks a voucher as deleted in the system (soft delete).

**Parameters:**
- `voucherId` (string): The ID of the voucher to mark as deleted

**Returns:**
- `Task<bool>`: True if deletion is successful, false otherwise

## Verification Functions

### VerifyVoucher
```csharp
Task<(bool success, decimal amount)> VerifyVoucher(string username, string voucherId)
```
Checks if a voucher can be redeemed by a specific user.

**Parameters:**
- `username` (string): The username of the user attempting to redeem
- `voucherId` (string): The ID of the voucher to verify

**Returns:**
- `Task<(bool success, decimal amount)>`: A tuple containing:
  - `success`: True if voucher can be redeemed, false otherwise
  - `amount`: The discount amount if successful, -1.00M if verification fails

## Notes
- All operations are asynchronous and return Task objects
- Voucher deletion is implemented as a soft delete (marked as deleted but not removed from database)
- GetAllVouchers only returns vouchers that haven't been marked as deleted
- The service does not support updating vouchers once created
- Voucher verification includes both validity checks and user eligibility
- Failed voucher verifications return a standard -1.00M amount
