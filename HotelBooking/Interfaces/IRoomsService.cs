using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{
    internal interface IRoomsService
    {
        /// <summary>
        /// This Method adds new room.
        /// </summary>
        /// <param name="room">New Room.</param>
        /// <returns></returns>
        Task CreateRoomAsync(Room room);
        /// <summary>
        ///  /// This method updates remaining room.
        /// </summary>
        /// <param name="id">Room id.</param>
        /// <param name="isAvailable"></param>
        /// <returns></returns>
        Task UpdateRoomAvailabilityAsync(int id, bool isAvailable);
        /// <summary>
        ///This method deletes rooms.
        /// </summary>
        /// <param name="id">Room id.</param>
        /// <returns></returns>
        Task DeleteRoomAsync(int id);
        /// <summary>
        /// This method returns rooms.
        /// </summary>
        /// <returns>All Rooms</returns>
        Task<ICollection<Room>> GetRoomsAsync();
        /// <summary>
        /// This method returns rooms by id.
        /// </summary>
        /// <param name="id">Room id.</param>
        /// <returns>Room</returns>
        Task<Room?> GetRoomByIdAsync(int id);
    }
}
