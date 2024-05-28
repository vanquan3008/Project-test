using System.ComponentModel.DataAnnotations;

namespace QLyProject.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name_Course { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Credits { get; set; } 
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }

    }
}

