using QLyProject.DTOs.RequestsDTO;
using QLyProject.Models;

namespace QLyProject.Services.IService
{
    public interface IEnrollmentService
    {
        public Task<Enrollments?> CreateEnrrollment(EnrollmentRequestDTO enrollment);
        public Task<Enrollments?> GetEnrollments(int id);
        public Task DeleteEnrollment(int id);
        public Task<Enrollments?> UpdateEnrrollment(EnrollmentRequestDTO enrollment, int id);
    }
}
