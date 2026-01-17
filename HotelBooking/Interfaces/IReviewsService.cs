using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{
    internal interface IReviewsService
    {
        /// <summary>
        /// This method adds a new review for a hotel.
        /// </summary>
        /// <param name="review">New Review.</param>
        /// <returns></returns>
        Task CreateReviewAsync(Review review);
        /// <summary>
        /// This method updates an existing review's rating and comment.
        /// </summary>
        /// <param name="reviewId">Review id.</param>
        /// <param name="newRating">New rating value.</param>
        /// <param name="newComment">New comment text.</param>
        /// <returns></returns>
        Task UpdateReviewAsync(int reviewId, int rating, string comment);
        /// <summary>
        /// This method deletes a review.
        /// </summary>
        /// <param name="reviewId">Review id.</param>
        /// <returns></returns>
        Task DeleteReviewAsync(int reviewId);
        /// <summary>
        /// This method returns all reviews for a specific hotel.
        /// </summary>
        /// <param name="hotelId">Hotel id.</param>
        /// <returns>Collection of Reviews for the hotel.</returns>
        Task<ICollection<Review>> GetReviewsByHotelAsync(int hotelId);
        /// <summary>
        /// This method returns a single review by id.
        /// </summary>
        /// <param name="reviewId">Review id.</param>
        /// <returns>Review</returns>
        Task<Review?> GetReviewByIdAsync(int reviewId);
    }
}
