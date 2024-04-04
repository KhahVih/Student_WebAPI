using System.ComponentModel.DataAnnotations;

namespace EFCore_API.Model
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
