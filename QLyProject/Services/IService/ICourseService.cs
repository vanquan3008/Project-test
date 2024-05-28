using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;

namespace QLyProject.Services.IService
{
    public interface ICourseService 
    {
        public Task<Courses?> CreateCourse(CourseRequestDTO course);
        public Task<Courses?> GetCourses(int id);
        public Task DeleteCourse(int id);
        public Task<Courses?> UpdateCourse(CourseRequestDTO course ,int id);
    }
}
