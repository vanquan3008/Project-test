using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;
using QLyProject.Services.IService;

namespace QLyProject.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Courses?> CreateCourse(CourseRequestDTO course)
        {
            Courses newCourse = new Courses
            {
                Name_Course = course.Name_Course,
                Description = course.Description,
                Credits = course.Credits,
                TeacherId = course.TeacherId
            };
            return await _courseRepository.CreateAsync(newCourse);
        }

        public async Task DeleteCourse(int id)
        {
            await _courseRepository.DeleteByIdAsync(id);
        }

        public async Task<Courses?> GetCourses(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<Courses?> UpdateCourse(CourseRequestDTO course, int id)
        {
            var courseUpdate = await _courseRepository.GetByIdAsync(id);
            courseUpdate.Name_Course = course.Name_Course ;
            courseUpdate.Credits = course.Credits;
            courseUpdate.Description = course.Description;
            courseUpdate.TeacherId = course.TeacherId;


            return await _courseRepository.UpdateAsync(courseUpdate);
        }
    }
}
