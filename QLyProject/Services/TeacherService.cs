using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;
using QLyProject.Repositorys;
using QLyProject.Repositorys.IRepository;
using QLyProject.Services.IService;

namespace QLyProject.Services
{
    public class TeacherService:ITeacherServices
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher?> CreateTeacher(TeacherRequestDTO teacher)
        {
            Teacher newTeacher = new Teacher
            {
                FullName = teacher.FullName,
                Description = teacher.Description,
                Email = teacher.Email,
                Phone_Number = teacher.Phone_Number
            };

            return await _teacherRepository.CreateAsync(newTeacher);
        }

        public async Task DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteByIdAsync(id);
        }

        public Task<Teacher?> GetTeacher(int id)
        {
            return _teacherRepository.GetByIdAsync(id);
        }

        public async Task<Teacher?> UpdateTeacher(Teacher teacher)
        {
            return await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
