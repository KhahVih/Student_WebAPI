using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_API.Model
{
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public Students? Student { get; set; }
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }
        public Courses? Course { get; set; }
    }
}
