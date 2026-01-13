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
    internal class RoomsService : IRoomsService
    {
        private readonly HotelBookingContext hotelBookingContext;
        public RoomsService()
        {
            hotelBookingContext = new HotelBookingContext();
        }
        /// <inheritdoc/>
        public async Task CreateRoomAsync(Room room)
        {
            await hotelBookingContext.Rooms.AddAsync(room);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task DeleteRoomAsync(int id)
        {
            var room = await hotelBookingContext.Rooms.FindAsync(id);
            if (room == null) { return; }

            hotelBookingContext.Rooms.Remove(room);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await hotelBookingContext.Rooms
            .Include(r => r.RoomImages)
            .FirstOrDefaultAsync(r => r.RoomId == id);
        }
        /// <inheritdoc/>
        public async Task<ICollection<Room>> GetRoomsAsync()
        {
            return await hotelBookingContext.Rooms
            .Include(r => r.Hotel)
            .Include(r => r.Type)
            .ToListAsync();
        }
        /// <inheritdoc/>
        public async Task UpdateRoomAvailabilityAsync(int id, bool isAvailable)
        {
            var room = await hotelBookingContext.Rooms.FindAsync(id);
            if (room == null) { return; }

            room.IsAvailable = isAvailable;
            await hotelBookingContext.SaveChangesAsync();
        }
    }
}
