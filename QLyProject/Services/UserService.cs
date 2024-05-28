using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;
using QLyProject.Services.IService;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace QLyProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> CreateUser(UserRequestDTO userDTO)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userDTO.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
             );
            User newUser = new User
            {
                Email = userDTO.Email,
                Age = userDTO.Age,
                Password = hashPass,
                IsAdmin = false,
                FullName = userDTO.FullName
            };
            return await _userRepository.CreateAsync(newUser);

        }
        public async Task<User?> GetUser(int id)
        {
            return await _userRepository.GetByIdAsync(id);

        }
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteByIdAsync(id);
        }
        public async Task<User?> UpdateUser(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    } 
}