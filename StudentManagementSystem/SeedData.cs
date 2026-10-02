using StudentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public static class SeedData
    {
        public static List<Student> LoadStudents() => new()
        {
            new Student { StudentId = 1,FullName = "Mohamed Elsayed" , Email ="mo7amed0518@gmail.com", DateOfBirth = new DateTime(2005, 11, 3), EnrollmentDate = new DateTime(2026, 9, 1)},

            new Student
             {
                StudentId = 2,
                 FullName = "Ahmed Hassan",
                 Email = "ahmed.hassan@.com",
                 DateOfBirth = new DateTime(2001, 3, 12),
                 EnrollmentDate = new DateTime(2026, 9, 2)
             },

             new Student
             {
                 StudentId = 3,
                 FullName = "Omar Ali",
                 Email = "omar.ali@.com",
                 DateOfBirth = new DateTime(2003, 7, 25),
                 EnrollmentDate = new DateTime(2026, 9, 3)
             },

             new Student
             {
                 StudentId = 4,
                 FullName = "Youssef Mohamed",
                 Email = "youssefmohamed@gmail.com",
                 DateOfBirth = new DateTime(2002, 11, 8),
                 EnrollmentDate = new DateTime(2026, 9, 4)
             },

             new Student
             {
                StudentId = 5,
                 FullName = "Mahmoud Adel",
                 Email = "mahmoud.adel@gmail.com",
                 DateOfBirth = new DateTime(2001, 12, 20),
                 EnrollmentDate = new DateTime(2026, 9, 5)
             }


        };


        public static List<Course> LoadCourses() => new()
        {
            new Course{CourseId = 1,Title = "EFCore",Credits = 3,Description = "Code_First Migration" ,InstructorId = 1},

            new Course {CourseId = 2, Title = "Physics", Credits = 3, Description = "Fundamentals of Physics" ,InstructorId = 1 },

            new Course { CourseId = 3, Title = "C#", Credits = 3,Description = "Fundamentals of C#"  }, // INstructor here null becouse the relationship is Optional

            new Course { CourseId = 4, Title = "Database Systems",Credits = 4, Description = "SQL Server and Database Design" ,InstructorId =2  },

          new Course {CourseId = 5,Title = "Programming",Credits = 4,Description = "Introduction to Programming and Problem Solving" ,InstructorId = 3 }
        };

        public static List<Enrollment> LoadEnrollments() => new()
        {
             new Enrollment
             {
                 StudentId = 1,
                 CourseId = 1,
                 EnrollmentDate = new DateTime(2026, 9, 1),
                 Grade = 95
             },

             new Enrollment
             {
                 StudentId = 1,
                 CourseId = 2,
                 EnrollmentDate = new DateTime(2026, 9, 1),
                 Grade = 88
             },

             new Enrollment
             {
                 StudentId = 2,
                 CourseId = 1,
                 EnrollmentDate = new DateTime(2026, 9, 2),
                 Grade = 90
             },

             new Enrollment
             {
                 StudentId = 2,
                 CourseId = 3,
                 EnrollmentDate = new DateTime(2026, 9, 2),
                 Grade = null
             },

             new Enrollment
             {
                 StudentId = 3,
                 CourseId = 2,
                 EnrollmentDate = new DateTime(2026, 9, 3),
                 Grade = 85
             },

             new Enrollment
             {
                 StudentId = 3,
                 CourseId = 4,
                 EnrollmentDate = new DateTime(2026, 9, 3),
                 Grade = null
             },

             new Enrollment
             {
                 StudentId = 4,
                 CourseId = 4,
                 EnrollmentDate = new DateTime(2026, 9, 4),
                 Grade = 92
             },

             new Enrollment
             {
                 StudentId = 4,
                 CourseId = 5,
                 EnrollmentDate = new DateTime(2026, 9, 4),
                 Grade = 89
             },

             new Enrollment
             {
                 StudentId = 5,
                 CourseId = 3,
                 EnrollmentDate = new DateTime(2026, 9, 5),
                 Grade = 94
             },

             new Enrollment
             {
                 StudentId = 5,
                 CourseId = 5,
                 EnrollmentDate = new DateTime(2026, 9, 5),
                 Grade = null

             }
        };

        public static List<Instructor> LoadInstructors() => new()
        {
            new Instructor
            {
                InstructorId = 1,
                FullName = "Issam abdelnaby"
            },
           
            new Instructor
            {
                InstructorId = 2,
                FullName = "Mohamed Hisham"
            },
           
            new Instructor
            {
                InstructorId = 3,
                FullName = "Omar Khaled"
            }
        };
    }
}
