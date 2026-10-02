using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }

       public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
         
    }
}
