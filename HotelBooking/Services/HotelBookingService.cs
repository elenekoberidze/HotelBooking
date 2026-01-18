using HotelBooking.Data;
using HotelBooking.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    internal class HotelBookingService : IHotelBookingService
    {
        private readonly HotelBookingContext hotelBookingContext;
        public HotelBookingService()
        {
            hotelBookingContext = new HotelBookingContext();
        }
        /// <inheritdoc/>
        public async Task<List<(int Id, string User, string Email, string First, string Last)>> GetActiveUsersWithProfiles()
        {
            var data = await hotelBookingContext.Users
                .Where(u => u.IsActive == true)
                .Select(u => new
                {
                    u.UserId,
                    Username = u.Username ?? string.Empty,
                    Email = u.Email ?? string.Empty,
                    FirstName = u.UserProfile!.FirstName ?? string.Empty,
                    LastName = u.UserProfile.LastName ?? string.Empty
                })
                .ToListAsync();

            return data.Select(x => (x.UserId, x.Username, x.Email, x.FirstName, x.LastName)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Hotel, string Room, string Type, string HotelImg, string RoomImg)>> GetAvailableRoomsWithImages()
        {
            var data = await hotelBookingContext.Rooms
                .Where(r => r.IsAvailable == true)
                .Select(r => new
                {
                    Hotel = r.Hotel.Name,
                    r.RoomNumber,
                    Type = r.Type.TypeName,
                    HImg = r.Hotel.HotelImages.Where(i => i.IsPrimary == true).Select(i => i.ImageUrl).FirstOrDefault() ?? "no-h.jpg",
                    RImg = r.RoomImages.Select(i => i.ImageUrl).FirstOrDefault() ?? "no-r.jpg"
                }).ToListAsync();
            return data.Select(x => (x.Hotel, x.RoomNumber, x.Type, x.HImg, x.RImg)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(int Id, string User, string Name)>> GetAllUsersWithProfiles()
        {
            var data = await hotelBookingContext.Users
                .Select(u => new { u.UserId, u.Username, FullName = u.UserProfile!.FirstName + " " + u.UserProfile.LastName })
                .ToListAsync();
            return data.Select(x => (x.UserId, x.Username, x.FullName)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Hotel, string Img)>> GetHotelsWithImagesLeft()
        {
            var data = await hotelBookingContext.Hotels
                .SelectMany(h => h.HotelImages.DefaultIfEmpty(), (h, img) => new { h.Name, Url = img != null ? (img.ImageUrl ?? "no-img.jpg") : "no-img.jpg" })
                .ToListAsync();
            return data.Select(x => (x.Name, x.Url)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Img, string Hotel)>> GetHotelsWithImagesRight()
        {
            var data = await hotelBookingContext.HotelImages
                .Select(i => new { i.ImageUrl, Hotel = i.Hotel.Name })
                .ToListAsync();
            return data.Select(x => (x.ImageUrl, x.Hotel)).ToList();
        }
        /// <inheritdoc/>
        public async Task<List<(int Id, string User, string Hotel, decimal Price)>> GetBookingDetails()
        {
            var data = await hotelBookingContext.Bookings
                .Select(b => new { b.BookingId, b.User.Username, Hotel = b.Room.Hotel.Name, b.TotalPrice })
                .ToListAsync();
            return data.Select(x => (x.BookingId, x.Username, x.Hotel, x.TotalPrice ?? 0)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string User, int Count)>> GetUserBookingCounts()
        {
            var data = await hotelBookingContext.Users
                .Select(u => new { u.Username, Count = u.Bookings.Count() })
                .ToListAsync();
            return data.Select(x => (x.Username, x.Count)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Hotel, double Avg)>> GetHotelAverageRating()
        {
            var data = await hotelBookingContext.Hotels
                .Select(h => new { h.Name, Avg = h.Reviews.Average(r => (double?)r.Rating) ?? 0 })
                .ToListAsync();
            return data.Select(x => (x.Name, x.Avg)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Hotel, decimal Income)>> GetHotelTotalIncome()
        {
            var data = await hotelBookingContext.Hotels
                .Select(h => new { h.Name, Income = h.Rooms.SelectMany(r => r.Bookings).Sum(b => (decimal?)b.TotalPrice) ?? 0 })
                .ToListAsync();
            return data.Select(x => (x.Name, x.Income)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(int UserId, DateOnly First, DateOnly Last)>> GetUserBookingDates()
        {
            var data = await hotelBookingContext.Bookings
                .GroupBy(b => b.UserId)
                .Select(g => new { UserId = g.Key, First = g.Min(b => b.CheckInDate), Last = g.Max(b => b.CheckOutDate) })
                .ToListAsync();
            return data.Select(x => (x.UserId, x.First, x.Last)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Type, decimal Min, decimal Max)>> GetRoomTypePriceRange()
        {
            var data = await hotelBookingContext.RoomTypes
                .GroupBy(rt => rt.TypeName)
                .Select(g => new { Type = g.Key, Min = g.Min(x => x.BasePrice), Max = g.Max(x => x.BasePrice) })
                .ToListAsync();
            return data.Select(x => (x.Type, x.Min, x.Max)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string City, decimal Min, decimal Max)>> GetCityRatingRange()
        {
            var data = await hotelBookingContext.Hotels
                .Where(h => h.Rating >= 3)
                .GroupBy(h => h.City)
                .Select(g => new { City = g.Key, Min = g.Min(x => x.Rating ?? 0), Max = g.Max(x => x.Rating ?? 0) })
                .ToListAsync();
            return data.Select(x => (x.City, x.Min, x.Max)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<(string Room, decimal Price, string Hotel)>> GetRoomsInTbilisiByPrice()
        {
            var data = await hotelBookingContext.Rooms
                .Where(r => r.Hotel.City.Equals("tbilisi", StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(r => r.Type.BasePrice)
                .Select(r => new { r.RoomNumber, r.Type.BasePrice, HotelName = r.Hotel.Name })
                .ToListAsync();
            return data.Select(x => (x.RoomNumber, x.BasePrice, x.HotelName)).ToList();
        }

      
    }
}