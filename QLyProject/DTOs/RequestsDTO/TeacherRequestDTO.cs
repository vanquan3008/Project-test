using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.RequestsDTO
{
    public class TeacherRequestDTO
    { 
        [Required]
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone_Number { get; set; } = string.Empty;
    }
}
