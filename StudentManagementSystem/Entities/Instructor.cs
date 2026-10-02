using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = string.Empty;         
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
