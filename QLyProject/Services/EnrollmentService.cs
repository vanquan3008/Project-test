using QLyProject.Models;
using QLyProject.Services.IService;
using QLyProject.Repositorys.IRepository;
using QLyProject.DTOs.RequestsDTO;
using Microsoft.EntityFrameworkCore;

namespace QLyProject.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<Enrollments?> CreateEnrrollment(EnrollmentRequestDTO enrollment)
        {


            Enrollments newEnrollment = new Enrollments
            {
                UserId = enrollment.UserId,
                CoursesID = enrollment.CourseID,
                Classroom = enrollment.Classroom,
                
            };

            return await _enrollmentRepository.CreateAsync(newEnrollment);

        }

        public async Task DeleteEnrollment(int id)
        {
            await _enrollmentRepository.DeleteByIdAsync(id);
        }

        public async Task<Enrollments?> GetEnrollments(int id)
        {
            return await _enrollmentRepository.GetByIdAsync(id);
        }

        public async Task<Enrollments?> UpdateEnrrollment(EnrollmentRequestDTO enrollment, int id)
        {
            var u_enrollment = await _enrollmentRepository.GetByIdAsync(id);
            u_enrollment.CoursesID = enrollment.CourseID;
            u_enrollment.UserId = enrollment.UserId;
            u_enrollment.Classroom = enrollment.Classroom;

            return await _enrollmentRepository.UpdateAsync(u_enrollment);
        }
    }
}
