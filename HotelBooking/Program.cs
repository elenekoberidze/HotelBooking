
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("hello world");


var usersService = new UsersService();


var existingUser = await usersService.GetUsersAsync();
if (!existingUser.Any(u => u.Email == "elene3@mail.com"))
{
    await usersService.CreateUserAsync(new User
    {
        Username = "ele",
        Email = "elene3@mail.com",
        PasswordHash = "hashedpassword",
        IsActive = true
    });
}


var hotelsService = new HotelsService();

await hotelsService.CreateHotelAsync(new Hotel
{
    Name = "Sun Hotel",
    City = "Tbilisi",
    Address = "Rustaveli Ave 10",
    Description = "Luxury hotel in the city center",
    Rating = 4.5m
});

await hotelsService.CreateHotelAsync(new Hotel
{
    Name = "Sea View",
    City = "Batumi",
    Address = "Beach Road 5",
    Description = "Hotel with sea view rooms",
    Rating = 4.8m
});
var roomsService = new RoomsService();

await roomsService.CreateRoomAsync(new Room
{
    HotelId = 1, 
    TypeId = 1,  
    RoomNumber = "101",
    IsAvailable = true
});

await roomsService.CreateRoomAsync(new Room
{
    HotelId = 1, 
    TypeId = 2,  
    RoomNumber = "102",
    IsAvailable = true
});
