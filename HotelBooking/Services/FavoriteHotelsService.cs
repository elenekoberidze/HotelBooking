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
    internal class FavoriteHotelsService : IFavoriteHotelsService
    {
        private readonly HotelBookingContext hotelBookingContext;

        public FavoriteHotelsService()
        {
            hotelBookingContext = new HotelBookingContext();
        }
        /// <inheritdoc/>
        public async Task AddFavoriteAsync(FavoriteHotel favorite)
        {
            favorite.SavedAt ??= DateTime.Now;
            await hotelBookingContext.FavoriteHotels.AddAsync(favorite);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task RemoveFavoriteAsync(int userId, int hotelId)
        {
            
            var favorite = await hotelBookingContext.FavoriteHotels.FindAsync(userId, hotelId);
            if (favorite == null) return;

            hotelBookingContext.FavoriteHotels.Remove(favorite);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task<ICollection<FavoriteHotel>> GetUserFavoritesAsync(int userId)
        {
            return await hotelBookingContext.FavoriteHotels
                .Include(f => f.Hotel)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
        /// <inheritdoc/>
        public async Task<bool> IsFavoriteAsync(int userId, int hotelId)
        {
            return await hotelBookingContext.FavoriteHotels
                .AnyAsync(f => f.UserId == userId && f.HotelId == hotelId);
        }
    }
}
