using StudentManagementSystem.Data;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Service;

namespace StudentManagementSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var context = new AppDbContext();

            var studentService = new StudentService(context);
            var courseService = new CourseService(context);
            var enrollmentService = new EnrollmentService(context);


            while (true)
            {
                try
                {
                    Console.Clear();


                    Console.WriteLine("======================================");
                    Console.WriteLine("       Student Management System");
                    Console.WriteLine("======================================");

                    Console.WriteLine("\n========== Student ==========");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Get Student By Id");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Delete Student");
                    Console.WriteLine("5. Search Student By Name");
                    Console.WriteLine("6. Get Student With All Enrollments");
                    Console.WriteLine("\n========== Course ==========");
                    Console.WriteLine("7. Add Course");
                    Console.WriteLine("8. Get Course By Id");
                    Console.WriteLine("9. Update Course");
                    Console.WriteLine("10. Delete Course");
                    Console.WriteLine("\n========== Enrollment ==========");
                    Console.WriteLine("11. Add Enrollment");
                    Console.WriteLine("12. Get Enrollment By Id");
                    Console.WriteLine("13. Update Enrollment");
                    Console.WriteLine("14. Delete Enrollment");
                    Console.WriteLine("15. Get Students By Course");
                    Console.WriteLine("16. Get Courses By Student");
                    Console.WriteLine("17. Get Average Grade Per Course");
                    Console.WriteLine("\n0. Exit");
                    Console.WriteLine("\n======================================");
                    Console.Write("Choose an option: ");

                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            await HandleAddStudent(studentService);
                            break;

                        case "2":
                            await HandleGetStudentById(studentService);
                            break;

                        case "3":
                            await HandleUpdateStudent(studentService);
                            break;

                        case "4":
                            await HandleDeleteStudent(studentService);
                            break;

                        case "5":
                            await HandleSearchStudentByName(studentService);
                            break;

                        case "6":
                            await HandleGetStudentWithEnrollments(studentService);
                            break;

                        case "7":
                            await HandleAddCourse(courseService);
                            break;

                        case "8":
                            await HandleGetCourseById(courseService);
                            break;

                        case "9":
                            await HandleUpdateCourse(courseService);
                            break;

                        case "10":
                            await HandleDeleteCourse(courseService);
                            break;

                        case "11":
                            await HandleAddEnrollment(enrollmentService);
                            break;

                        case "12":
                            await HandleGetEnrollmentById(enrollmentService);
                            break;

                        case "13":
                            await HandleUpdateEnrollment(enrollmentService);
                            break;

                        case "14":
                            await HandleDeleteEnrollment(enrollmentService);
                            break;

                        case "15":
                            await HandleGetStudentsByCourse(enrollmentService);
                            break;

                        case "16":
                            await HandleGetCoursesByStudent(enrollmentService);
                            break;

                        case "17":
                            await HandleGetAverageGradePerCourse(enrollmentService);
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("\nInvalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Masseage : {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");


                Console.ReadKey();
            }
        }

        static async Task HandleAddStudent(StudentService studentService)
        {
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Date Of Birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Enrollment Date (yyyy-MM-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Student student = new Student
            {
                StudentId = id,
                FullName = name,
                Email = email,
                DateOfBirth = dateOfBirth,
                EnrollmentDate = enrollmentDate
            };

            await studentService.AddStudentAsync(student);

            Console.WriteLine("Student added successfully.");
        }
        static async Task HandleGetStudentById(StudentService studentService)
        {
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            var student = await studentService.GetStudentById(id);

            if (student is null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"Id: {student.StudentId}");
            Console.WriteLine($"Name: {student.FullName}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine($"Date Of Birth: {student.DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Enrollment Date: {student.EnrollmentDate:yyyy-MM-dd}");
        }

        static async Task HandleUpdateStudent(StudentService studentService)
        {
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Full Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter New Date Of Birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New Enrollment Date (yyyy-MM-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Student student = new Student
            {
                StudentId = id,
                FullName = name,
                Email = email,
                DateOfBirth = dateOfBirth,
                EnrollmentDate = enrollmentDate
            };

            var result = await studentService.UpdateStudentByAsync(student);

            if (result is null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Student updated successfully.");
        }

        static async Task HandleDeleteStudent(StudentService studentService)
        {
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            Student student = new Student
            {
                StudentId = id
            };

            bool result = await studentService.DeleteStudentByAsync(student);

            if (!result)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Student deleted successfully.");
        }

        static async Task HandleSearchStudentByName(StudentService studentService)
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            var students = await studentService.SearchByNameAsync(name);

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.StudentId} | Name: {student.FullName} | Email: {student.Email}");
            }
        }

        static async Task HandleGetStudentWithEnrollments(StudentService studentService)
        {
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            var student = await studentService.GetStudentById(id);

            if (student is null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var result = await studentService.StudentWithallEnrollmentsAsync(student);

            if (result is null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"Student: {result.FullName}");
            Console.WriteLine("Enrollments:");

            foreach (var enrollment in result.Enrollments)
            {
                Console.WriteLine(
                    $"Course Id: {enrollment.CourseId} | Date: {enrollment.EnrollmentDate:yyyy-MM-dd} | Grade: {enrollment.Grade}");
            }
        }


        static async Task HandleAddCourse(CourseService courseService)
        {
            Console.Write("Enter Course Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Title : ");
            string title = Console.ReadLine();

            Console.Write("Enter Credits : ");
            int credits = int.Parse(Console.ReadLine());

            Console.Write("Enter Description : ");
            string description = Console.ReadLine();

            Console.Write("Enter Instructor Id : ");
            string instructorInput = Console.ReadLine();

            int? instructorId = null;

            if (!string.IsNullOrWhiteSpace(instructorInput))
            {
                instructorId = int.Parse(instructorInput);
            }

            Course course = new Course
            {
                CourseId = id,
                Title = title,
                Credits = credits,
                Description = description,
                InstructorId = instructorId
            };

            await courseService.AddCourseAsync(course);

            Console.WriteLine("Course added successfully.");
        }

        static async Task HandleGetCourseById(CourseService courseService)
        {
            Console.Write("Enter Course Id: ");
            int id = int.Parse(Console.ReadLine());

            var course = await courseService.GetCoursetById(id);

            if (course is null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine($"Course Id: {course.CourseId}");
            Console.WriteLine($"Title: {course.Title}");
            Console.WriteLine($"Credits: {course.Credits}");
            Console.WriteLine($"Description: {course.Description}");
            Console.WriteLine($"Instructor Id: {course.InstructorId}");
        }

        static async Task HandleUpdateCourse(CourseService courseService)
        {
            Console.Write("Enter Course Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter New Credits: ");
            int credits = int.Parse(Console.ReadLine());

            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();

            Course course = new Course
            {
                CourseId = id,
                Title = title,
                Credits = credits,
                Description = description
            };

            var result = await courseService.UpdateCourseByAsync(course);

            if (result is null)
            {
                Console.WriteLine("Course not founded.");
                return;
            }

            Console.WriteLine("Course updated successfully.");
        }

        static async Task HandleDeleteCourse(CourseService courseService)
        {
            Console.Write("Enter Course Id: ");
            int id = int.Parse(Console.ReadLine());

            Course course = new Course
            {
                CourseId = id
            };

            bool result = await courseService.DeleteCourseByAsync(course);

            if (!result)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine("Course deleted successfully.");
        }

        static async Task HandleAddEnrollment(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Enrollment Date : ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Grade : ");
            string gradeInput = Console.ReadLine();

            int? grade = null;

            if (!string.IsNullOrWhiteSpace(gradeInput))
            {
                grade = int.Parse(gradeInput);
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = enrollmentDate,
                Grade = grade
            };

            await enrollmentService.AddEnrollmentAsync(enrollment);

            Console.WriteLine("Enrollment added successfully.");
        }


        static async Task HandleGetEnrollmentById(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            var enrollment = await enrollmentService.GetEnrollmenttById(studentId, courseId);

            if (enrollment is null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            Console.WriteLine($"Student Id: {enrollment.StudentId}");
            Console.WriteLine($"Course Id: {enrollment.CourseId}");
            Console.WriteLine($"Enrollment Date: {enrollment.EnrollmentDate:yyyy-MM-dd}");
            Console.WriteLine($"Grade: {enrollment.Grade}");
        }
        static async Task HandleUpdateEnrollment(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Enrollment Date (yyyy-MM-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New Grade : ");
            string gradeInput = Console.ReadLine();

            int? grade = null;

            if (!string.IsNullOrWhiteSpace(gradeInput))
            {
                grade = int.Parse(gradeInput);
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = enrollmentDate,
                Grade = grade
            };

            var result = await enrollmentService.UpdateEnrollmentByAsync(enrollment);

            if (result is null)
            {
                Console.WriteLine("Enrollment not founded.");
                return;
            }

            Console.WriteLine("Enrollment updated successfully.");
        }

        static async Task HandleDeleteEnrollment(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            bool result = await enrollmentService.DeleteEnrollmentByAsync(enrollment);

            if (!result)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            Console.WriteLine("Enrollment deleted successfully.");
        }
        static async Task HandleGetStudentsByCourse(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            var students = await enrollmentService.GetStudentsByCourseAsync(courseId);

            if (students.Count == 0)
            {
                Console.WriteLine("No students found for this course.");
                return;
            }

            Console.WriteLine("Students:");

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Id: {student.StudentId} | Name:{student.FullName} | Email: {student.Email}");
            }
        }
        static async Task HandleGetCoursesByStudent(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            var enrollments = await enrollmentService.GetCoursesByStudentAsync(studentId);

            if (enrollments.Count == 0)
            {
                Console.WriteLine("No courses found for this student.");
                return;
            }

            Console.WriteLine("Courses:");

            foreach (var enrollment in enrollments)
            {
                Console.WriteLine($"Course Id: {enrollment.CourseId} |Course: {enrollment.Course.Title} | Grade: {enrollment.Grade}");
            }
        }
        static async Task HandleGetAverageGradePerCourse(EnrollmentService enrollmentService)
        {
            Console.Write("Enter Course Id : ");
            int courseId = int.Parse(Console.ReadLine());

            var average = await enrollmentService.GetAverageGradePerCourseAsync(courseId);

            if (average is null)
            {
                Console.WriteLine("No grades founded for this course.");
                return;
            }

            Console.WriteLine($"Average Grade : {average}");
        }
    }
}
