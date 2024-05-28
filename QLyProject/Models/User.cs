using System.ComponentModel.DataAnnotations;

namespace QLyProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
    }
}
