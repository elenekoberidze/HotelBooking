using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    internal class HotelBookingService(HotelBookingContext context)
    {
        private readonly HotelBookingContext hotelBookingContext = context;

        public async Task GetActiveUsersWithProfiles()
        {
            var result = await hotelBookingContext.Users
                .Where(u => u.IsActive == true)
                .Select(u => new {
                    u.UserId,
                    u.Username,
                    u.Email,
                    u.UserProfile!.FirstName,
                    u.UserProfile.LastName,
                    u.UserProfile.PhoneNumber
                }).ToListAsync();
        }


        public async Task GetAvailableRoomsWithImages()
        {
            var result = await hotelBookingContext.Rooms
                .Where(r => r.IsAvailable == true)
                .Select(r => new {
                    HotelName = r.Hotel.Name,
                    r.RoomNumber,
                    r.Type.TypeName,
                    HotelPhoto = r.Hotel.HotelImages
                        .FirstOrDefault(hi => hi.IsPrimary == true) != null
                        ? r.Hotel.HotelImages.FirstOrDefault(hi => hi.IsPrimary == true)!.ImageUrl
                        : "no-hotel-image.jpg",
                    RoomPhoto = r.RoomImages.FirstOrDefault() != null
                        ? r.RoomImages.FirstOrDefault()!.ImageUrl
                        : "no-room-image.jpg"
                }).ToListAsync();
        }

        public async Task GetAllUsersWithProfiles()
        {
            var result = await hotelBookingContext.Users
                .Select(static u => new {
                    u.UserId,
                    u.Username,
                    u.UserProfile!.FirstName,
                    u.UserProfile.LastName,
                    u.UserProfile.PhoneNumber
                }).ToListAsync();
        }


        public async Task GetHotelsWithImagesLeft()
        {
            var result = await hotelBookingContext.Hotels
                .SelectMany(h => h.HotelImages.DefaultIfEmpty(), (h, hi) => new {
                    h.HotelId,
                    HotelName = h.Name,
                    ImageUrl = hi != null ? hi.ImageUrl : "no-image.jpg",
                    IsPrimary = hi != null ? hi.IsPrimary : false
                }).ToListAsync();
        }


        public async Task GetBookingDetails()
        {
            var result = await hotelBookingContext.Bookings
                .Select(b => new {
                    b.BookingId,
                    b.User.Username,
                    HotelName = b.Room.Hotel.Name,
                    b.Room.RoomNumber,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.TotalPrice
                }).ToListAsync();
        }

       
        public async Task GetUserBookingCounts()
        {
            var result = await hotelBookingContext.Users
                .Select(u => new {
                    u.UserId,
                    u.Username,
                    TotalBookings = u.Bookings.Count()
                }).ToListAsync();
        }

       
        public async Task GetHotelAverageRating()
        {
            var result = await hotelBookingContext.Hotels
                .Select(h => new {
                    h.HotelId,
                    HotelName = h.Name,
                    AverageRating = h.Reviews.Any() ? h.Reviews.Average(r => r.Rating) : 0
                }).ToListAsync();
        }

       
        public async Task GetHotelTotalIncome()
        {
            var result = await hotelBookingContext.Hotels
                .Select(h => new {
                    HotelName = h.Name,
                    TotalIncome = h.Rooms.SelectMany(r => r.Bookings).Sum(b => (decimal?)b.TotalPrice) ?? 0
                }).ToListAsync();
        }

    
        public async Task GetUserBookingDates()
        {
            var result = await hotelBookingContext.Bookings
                .GroupBy(b => b.UserId)
                .Select(g => new {
                    UserId = g.Key,
                    FirstBooking = g.Min(b => b.CheckInDate),
                    LastBooking = g.Max(b => b.CheckOutDate)
                }).ToListAsync();
        }

       
        public async Task GetRoomTypePriceRange()
        {
            var result = await hotelBookingContext.RoomTypes
                .GroupBy(rt => rt.TypeName)
                .Select(g => new {
                    TypeName = g.Key,
                    MinPrice = g.Min(rt => rt.BasePrice),
                    MaxPrice = g.Max(rt => rt.BasePrice)
                }).ToListAsync();
        }

        
        public async Task GetCityRatingRange()
        {
            var result = await hotelBookingContext.Hotels
                .Where(h => h.Rating >= 3)
                .GroupBy(h => h.City)
                .Select(g => new {
                    City = g.Key,
                    MinRating = g.Min(h => h.Rating),
                    MaxRating = g.Max(h => h.Rating)
                }).ToListAsync();
        }

   
        public async Task GetRoomsInTbilisiByPrice()
        {
            var result = await hotelBookingContext.Rooms
                .Where(r => r.Hotel.City.Equals("tbilisi", StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(r => r.Type.BasePrice)
                .Select(r => new {
                    r.RoomId,
                    r.RoomNumber,
                    r.Type.BasePrice,
                    HotelName = r.Hotel.Name
                }).ToListAsync();
        }

       
        public async Task GetHotelsByRevenue()
        {
            var result = await hotelBookingContext.Hotels
                .Select(h => new {
                    h.HotelId,
                    h.Name,
                    TotalRevenue = h.Rooms.SelectMany(r => r.Bookings).Sum(b => (decimal?)b.TotalPrice) ?? 0
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToListAsync();
        }
    }
}
