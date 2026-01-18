
using HotelBooking.Data;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Services;
using Microsoft.EntityFrameworkCore;
using HotelBooking.ConsoleApp;

var context = new HotelBookingContext();
IUserService userService = new UsersService(context);

var userConsole = new UserConsole(userService);

await userConsole.CreateUserAsync();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();









