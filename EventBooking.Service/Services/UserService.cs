using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }
        public Task<UserModel> Update(UserModel usuario)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Add(UserModel pUser)
        {
            var user = new User(pUser.Name, pUser.Email);

            if (pUser.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pUser.Password));
                byte[] passwordSalt = hmac.Key;

                user.AlterarSenha(passwordHash, passwordSalt);
            }

            _userRepository.Create(user);
            
            return pUser;
        }
    }
}
