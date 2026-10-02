using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? Grade { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }

}
