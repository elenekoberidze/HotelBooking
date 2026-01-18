using HotelBooking.Data;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    internal class UsersService(HotelBookingContext context) : IUserService
    {
        private readonly HotelBookingContext hotelBookingContext = context;

        /// <inheritdoc/>
        public async Task CreateUserAsync(User user, UserProfile profile)
        {
            bool emailExists = await hotelBookingContext.Users
                .AnyAsync(u => u.Email == user.Email);

            if (emailExists)
                throw new Exception("Email already exists");

            await hotelBookingContext.Users.AddAsync(user);
            await hotelBookingContext.UserProfiles.AddAsync(profile);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task DeleteUserAsync(int id)
        {
            var user = await hotelBookingContext.Users
                .Include(u => u.UserProfile)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            { return; }

            hotelBookingContext.Users.Remove(user);
            await hotelBookingContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateUserAsync(int id, string name, string surname)
        {
            var profile = await hotelBookingContext.UserProfiles
                .FirstOrDefaultAsync(p => p.UserId == id);

            if (profile == null)
            { return; }

            profile.FirstName = name;
            profile.LastName = surname;

            await hotelBookingContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateUserMailAsync(int id, string newMail)
        {
            var user = await hotelBookingContext.Users.FindAsync(id);

            if (user == null)
            { return; }

            user.Email = newMail;
            await hotelBookingContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await hotelBookingContext.Users
                .Include(u => u.UserProfile)
                .OrderBy(u => u.Username)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await hotelBookingContext.Users
                .Include(u => u.UserProfile)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

       
        }
    }

