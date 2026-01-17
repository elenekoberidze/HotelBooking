using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{

    
    public interface IBookingsService
    {
        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="booking">New Booking details.</param>
        /// <returns></returns>
        Task CreateBookingAsync(Booking booking);

        /// <summary>
        /// Updates the dates for an existing booking.
        /// </summary>
        /// <param name="id">Booking ID.</param>
        /// <param name="checkIn">New Check-in date.</param>
        /// <param name="checkOut">New Check-out date.</param>
        /// <returns></returns>
        Task UpdateBookingDatesAsync(int id, DateOnly checkIn, DateOnly checkOut);

        /// <summary>
        /// Deletes a booking record.
        /// </summary>
        /// <param name="id">Booking ID.</param>
        /// <returns></returns>
        Task DeleteBookingAsync(int id);

        /// <summary>
        /// Returns all bookings with Room and User details.
        /// </summary>
        /// <returns>A collection of all bookings.</returns>
        Task<ICollection<Booking>> GetBookingsAsync();

        /// <summary>
        /// Returns a specific booking by its ID.
        /// </summary>
        /// <param name="id">Booking ID.</param>
        /// <returns>Booking details or null if not found.</returns>
        Task<Booking?> GetBookingByIdAsync(int id);
    }
}

