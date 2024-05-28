using System.ComponentModel.DataAnnotations;

namespace QLyProject.DTOs.RequestsDTO
{
    public class CourseRequestDTO
    {

        [Required]
        public string Name_Course { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public int? Credits { get; set; } = 0;
        public int TeacherId { get; set; } = 0;
    }
}
