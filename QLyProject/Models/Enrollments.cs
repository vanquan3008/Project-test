using System.ComponentModel.DataAnnotations;

namespace QLyProject.Models
{
    public class Enrollments
    {
        [Key]
        public int Id { get; set; }
        public int  CoursesID { get; set; }
        public virtual Courses? Courses { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public string Classroom { get; set; } = string.Empty;
    }
}
