using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Interfaces
{
    internal interface IUserService
    {
        /// <summary>
        /// This method adds new user.
        /// </summary>
        /// <param name="user">New user.</param>
        Task CreateUserAsync(User user, UserProfile profile);

        /// <summary>
        /// This method deletes user.
        /// </summary>
        /// <param name="id">User id.</param>
        Task DeleteUserAsync(int id);

        /// <summary>
        /// This updates name and surname.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        Task UpdateUserAsync(int id, string name, string surname);


        /// <summary>
        /// This method updates mail.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newMail"></param>
        Task UpdateUserMailAsync(int id, string newMail);

        /// <summary>
        /// This Method returns all USers from Database.
        /// </summary>
        /// <returns>All Users.</returns>
        Task<ICollection<User>> GetUsersAsync();

        /// <summary>
        /// This Method returns User by Id.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        Task<User?> GetUserByIdAsync(int id);
        

    }
}
