
using HotelBooking.Data;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.EntityFrameworkCore;
using HotelBooking.ConsoleUI;

var context = new HotelBookingContext();
IUserService userService = new UsersService(context);

var userConsole = new UserConsole(userService);

await userConsole.CreateUserAsync();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


//IHotelsService hotelsService = new HotelsService();
//IRoomsService roomsService = new RoomsService();
//IReviewsService reviewsService = new ReviewsService();

//var hotel = new Hotel
//{
//    Name = "Sunrise Hotel",
//    City = "Tbilisi",
//    Address = "Rustaveli Avenue 25",
//    Description = "Comfortable hotel in city center",
//    Rating = 4.5m
//};

//await hotelsService.CreateHotelAsync(hotel);

//Console.WriteLine($"Hotel created with ID: {hotel.HotelId}");


//var room = new Room
//{
//    HotelId = hotel.HotelId, 
//    TypeId = 1,             
//    RoomNumber = "101",
//    IsAvailable = true
//};

//await roomsService.CreateRoomAsync(room);

//Console.WriteLine($"Room created with ID: {room.RoomId}");


//var review = new Review
//{
//    HotelId = hotel.HotelId, 
//    UserId = 1,             
//    Rating = 5,
//    Comment = "Excellent service and clean rooms!"
//};

//await reviewsService.CreateReviewAsync(review);

//Console.WriteLine("Review added successfully!");
    








