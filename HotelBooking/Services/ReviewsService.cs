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
    internal class ReviewsService : IReviewsService
    {
        private readonly HotelBookingContext hotelBookingContext;

        public ReviewsService()
        {
            hotelBookingContext = new HotelBookingContext();
        }
        /// <inheritdoc/>
        public async Task CreateReviewAsync(Review review)
        {
            review.ReviewDate ??= DateTime.Now;
            await hotelBookingContext.Reviews.AddAsync(review);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await hotelBookingContext.Reviews.FindAsync(reviewId);
            if (review == null) return;

            hotelBookingContext.Reviews.Remove(review);
            await hotelBookingContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task<Review?> GetReviewByIdAsync(int reviewId)
        {
            return await hotelBookingContext.Reviews
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }
        /// <inheritdoc/>
        public async Task<ICollection<Review>> GetReviewsByHotelAsync(int hotelId)
        {
            return await hotelBookingContext.Reviews
                .Include(r => r.User)
                .Where(r => r.HotelId == hotelId)
                .OrderByDescending(r => r.ReviewDate)
                .ToListAsync();
        }
        /// <inheritdoc/>
        public async Task UpdateReviewAsync(int reviewId, int rating, string comment)
        {
            var review = await hotelBookingContext.Reviews.FindAsync(reviewId);
            if (review == null) return;

            review.Rating = rating;
            review.Comment = comment;
            review.ReviewDate = DateTime.Now; 

            await hotelBookingContext.SaveChangesAsync();
        }
    }
}
