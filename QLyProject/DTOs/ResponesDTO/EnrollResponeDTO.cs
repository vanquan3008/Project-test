using QLyProject.Models;

namespace QLyProject.DTOs.ResponesDTO
{
    public class EnrollResponeDTO
    {
        public int CoursesID { get; set; }
        public int UserId { get; set; }
        public string Classroom { get; set; } = string.Empty;
    }
}
