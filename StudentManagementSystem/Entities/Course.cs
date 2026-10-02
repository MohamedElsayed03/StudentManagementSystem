using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; } =  null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
