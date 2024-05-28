using QLyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.RequestsDTO
{
    public class EnrollmentRequestDTO
    { 

        [Required]
        public int CourseID { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Classroom { get; set; } = string.Empty;
    }
}
