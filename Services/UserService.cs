using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Backend.Challenge.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(UserDto user)
        {
            _userRepository.Insert(user);
        }

        public GetUserResponse GetUsers(IEnumerable<int> id)
        {
            var response = new GetUserResponse();
            if (id.Count() == 0)
            {
                response.Users = _userRepository.GetAll().ToDictionary(u => Int32.Parse(u.Id), u => u);
            }
            else
            {
                var ids = id.Select(id => id.ToString());
                var users = _userRepository.GetByKeys(ids);
                response.Users = users.Values.ToDictionary(u => Int32.Parse(u.Id), u => u);
            }
            return response;
        }
    }
}
