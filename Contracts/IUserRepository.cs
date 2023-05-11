using Backend.Challenge.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Contracts
{
    public interface IUserRepository : IRepository<UserDto>
    {
        /// <summary>
        /// Get all Users except one with userId
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <returns></returns>
        public IList<UserDto> GetAllExcept(string userId);
    }
}
