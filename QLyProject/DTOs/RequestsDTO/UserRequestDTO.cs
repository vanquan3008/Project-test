using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.RequestsDTO
{
    public class UserRequestDTO
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
