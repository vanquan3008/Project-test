
using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;
namespace QLyProject.Services.IService
{
    public interface IUserService
    {
        public Task<User?> CreateUser(UserRequestDTO User);
        public Task<User?> GetUser(int id);
        public Task DeleteUser(int id);
        public Task<User?> UpdateUser(User user);
    }
}
