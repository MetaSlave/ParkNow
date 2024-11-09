# BookingService

> See complete implementation at `ParkNow.Services.BookingService`

The `BookingService` class provides methods to manage booking operations within the ParkNow system. It includes CRUD operations for bookings as well as additional utility functions like price calculation.

## CRUD Operations

### CreateBooking

#### Without Voucher
```csharp
Task<bool> CreateBooking(Booking booking)
```
Creates a new booking in the system.

**Parameters:**
- `booking` (Booking): The booking entity to be created

**Returns:**
- `Task<bool>`: True if creation is successful, false otherwise

#### With Voucher
```csharp
Task<bool> CreateBooking(Booking booking, Voucher voucher)
```
Creates a new booking with an applied voucher discount.

**Parameters:**
- `booking` (Booking): The booking entity to be created
- `voucher` (Voucher): The voucher to be applied to the booking

**Returns:**
- `Task<bool>`: True if creation is successful, false otherwise

### GetUserBookings
```csharp
Task<List<Booking>> GetUserBookings(string username)
```
Retrieves all active (non-deleted) bookings for a specific user.

**Parameters:**
- `username` (string): The username to search bookings for

**Returns:**
- `Task<List<Booking>>`: List of bookings associated with the user, or empty list if none found

### GetBooking
```csharp
Task<Booking> GetBooking(int bookingId)
```
Retrieves a specific booking by its ID.

**Parameters:**
- `bookingId` (int): The ID of the booking to retrieve

**Returns:**
- `Task<Booking>`: The requested booking entity, or null if not found

### UpdateBooking
```csharp
Task<bool> UpdateBooking(Booking booking)
```
Updates an existing booking's information (start time, end time, cost, and status).

**Parameters:**
- `booking` (Booking): The booking entity with updated information

**Returns:**
- `Task<bool>`: True if update is successful, false otherwise

### DeleteBooking
```csharp
Task<bool> DeleteBooking(int bookingId)
```
Marks a booking as deleted in the system (soft delete).

**Parameters:**
- `bookingId` (int): The ID of the booking to mark as deleted

**Returns:**
- `Task<bool>`: True if deletion is successful, false otherwise

## Utility Functions

### CalculatePrice
```csharp
decimal CalculatePrice(DateTime start, DateTime end, Carpark carpark)
```
Calculates the parking fee for a specific time range at a given carpark.

**Parameters:**
- `start` (DateTime): Start time of the parking period
- `end` (DateTime): End time of the parking period
- `carpark` (Carpark): The carpark entity to calculate price for

**Returns:**
- `decimal`: Calculated price for the parking duration, or 0 if parking is not available for the specified time range

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
