using Backend.Challenge.Dtos;
using Backend.Challenge.ServiceModels;
using System.Collections.Generic;

namespace Backend.Challenge.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns></returns>
        public void CreateUser(UserDto user);

        /// <summary>
        /// Deletes and returns UnseenComments with entityId and userId.
        /// </summary>
        /// <param name="id">The list of ids.</param>
        /// <returns></returns>
        public GetUserResponse GetUsers(IEnumerable<int> id);
    }
}
