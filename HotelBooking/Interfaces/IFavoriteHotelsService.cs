using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{
    internal interface IFavoriteHotelsService
    {
        /// <summary>
        /// This method adds a hotel to a user's favorites.
        /// </summary>
        /// <param name="favorite">The favorite hotel entity to add.</param>
        /// <returns></returns>
        Task AddFavoriteAsync(FavoriteHotel favorite);
        /// <summary>
        /// This method removes a hotel from a user's favorites.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="hotelId">The ID of the hotel to remove.</param>
        /// <returns></returns>
        Task RemoveFavoriteAsync(int userId, int hotelId);
        /// <summary>
        /// This method returns all favorite hotels for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns></returns>
        Task<ICollection<FavoriteHotel>> GetUserFavoritesAsync(int userId);
        // <summary>
        /// This method checks if a specific hotel is already favorited by a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="hotelId">The ID of the hotel.</param>
        /// <returns>True if the hotel is a favorite; otherwise, false.</returns>
        Task<bool> IsFavoriteAsync(int userId, int hotelId);
    }
}
