using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.RequestsDTO
{
    public class UserUpdateRequestDTO
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
