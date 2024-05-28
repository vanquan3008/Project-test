using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;

namespace QLyProject.Services.IService
{
    public interface ITeacherServices
    {
        public Task<Teacher?> CreateTeacher(TeacherRequestDTO teacher);
        public Task<Teacher?> GetTeacher(int id);
        public Task DeleteTeacher(int id);
        public Task<Teacher?> UpdateTeacher(Teacher teacher);
    }
}
