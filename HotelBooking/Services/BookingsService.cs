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
    internal class BookingsService : IBookingsService
    {
        private readonly HotelBookingContext hotelBookingContext;

        public BookingsService()
        {
            hotelBookingContext = new HotelBookingContext();
        }

        /// <inheritdoc/>
        public async Task CreateBookingAsync(Booking booking)
        {
            
            booking.CreatedAt ??= DateTime.Now;

            await hotelBookingContext.Bookings.AddAsync(booking);
            await hotelBookingContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteBookingAsync(int id)
        {
            var booking = await hotelBookingContext.Bookings.FindAsync(id);
            if (booking == null) { return; }

            hotelBookingContext.Bookings.Remove(booking);
            await hotelBookingContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await hotelBookingContext.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        /// <inheritdoc/>
        public async Task<ICollection<Booking>> GetBookingsAsync()
        {
            return await hotelBookingContext.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateBookingDatesAsync(int id, DateOnly checkIn, DateOnly checkOut)
        {
            var booking = await hotelBookingContext.Bookings.FindAsync(id);
            if (booking == null) { return; }

            booking.CheckInDate = checkIn;
            booking.CheckOutDate = checkOut;

            await hotelBookingContext.SaveChangesAsync();
        }
    }
}