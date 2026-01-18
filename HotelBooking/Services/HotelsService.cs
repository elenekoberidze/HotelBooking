using HotelBooking.Data;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    internal class HotelsService : IHotelsService
    {
        private readonly HotelBookingContext hotelBookingContext;
        public HotelsService()
        {
            hotelBookingContext = new HotelBookingContext();    
        }
        /// <inheritdoc/>
        public async Task CreateHotelAsync(Hotel hotel)
        {
            await hotelBookingContext.Hotels.AddAsync(hotel);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await hotelBookingContext.Hotels.FindAsync(id);
            if (hotel == null) { return; }
            hotelBookingContext.Hotels.Remove(hotel);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task<Hotel?> GetHotelByIdAsync(int id)
        {
            return await hotelBookingContext.Hotels
           .Include(h => h.Rooms)
           .FirstOrDefaultAsync(h => h.HotelId == id);
        }
        /// <inheritdoc/>
        public async Task<ICollection<Hotel>> GetHotelsAsync()
        {
            return await hotelBookingContext.Hotels
            .OrderByDescending(h => h.Rating)
            .ToListAsync();
        }
        /// <inheritdoc/>
        public async Task UpdateHotelAsync(int id, string name, string city)
        {
            var hotel = await hotelBookingContext.Hotels.FindAsync(id);
            if (hotel == null) { return; }
            hotel.Name = name;
            hotel.City = city;
            await hotelBookingContext.SaveChangesAsync();
        }

    }
}
