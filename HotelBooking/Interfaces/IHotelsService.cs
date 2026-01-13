using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{
    internal interface IHotelsService
    {
        /// <summary>
        /// This method adds new hotel.
        /// </summary>
        /// <param name="hotel">New Hotel.</param>
        /// <returns></returns>
        Task CreateHotelAsync(Hotel hotel);
        /// <summary>
        /// This methods updates remaining hotel.
        /// </summary>
        /// <param name="id">Hotel Id.</param>
        /// <param name="name">Hotel Name.</param>
        /// <param name="city">Hotel City.</param>
        /// <returns></returns>
        Task UpdateHotelAsync(int id, string name, string city);
        /// <summary>
        /// This method deletes hotel.
        /// </summary>
        /// <param name="id">Hotel Id.</param>
        /// <returns></returns>
        Task DeleteHotelAsync(int id);
        /// <summary>
        /// This method returns hotels.
        /// </summary>
        /// <returns>All Hotels.</returns>
        Task<ICollection<Hotel>> GetHotelsAsync();
        /// <summary>
        /// This method returns hotels by id.
        /// </summary>
        /// <param name="id">Hotel Id.</param>
        /// <returns>Hotel</returns>
        Task<Hotel?> GetHotelByIdAsync(int id);
    }
}
