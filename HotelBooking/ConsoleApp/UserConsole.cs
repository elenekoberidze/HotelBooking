
using System;
using HotelBooking.Models;
using HotelBooking.Interfaces;

namespace HotelBooking.ConsoleApp
{
    internal class UserConsole(IUserService userService)
    {
        private readonly IUserService userService = userService;

        public async Task CreateUserAsync()
        {
            Console.WriteLine("--- Create New User ---");

            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            Console.Write("First name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Last name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Phone number (optional): ");
            string? phone = Console.ReadLine();

            Console.Write("Address (optional): ");
            string? address = Console.ReadLine();

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = password,
                IsActive = true
            };

            var profile = new UserProfile
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone,
                Address = string.IsNullOrWhiteSpace(address) ? null : address,
                User = user! 
            };

            await userService.CreateUserAsync(user, profile);

            Console.WriteLine("User created successfully!");
        }
    }
}
