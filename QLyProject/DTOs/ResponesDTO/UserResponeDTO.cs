using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.ResponesDTO
{
    public class UserResponeDTO
    {
        public int Age { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
