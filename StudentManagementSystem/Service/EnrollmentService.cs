using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Service
{
    public class EnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);

            await _context.SaveChangesAsync();
        }


        public async Task<Enrollment?> GetEnrollmenttById(int studentid , int courseid)
        {
            return await _context.Enrollments.AsNoTracking().FirstOrDefaultAsync(c => c.CourseId == courseid && c.StudentId == studentid);
        }

        public async Task<Enrollment?> UpdateEnrollmentByAsync(Enrollment enrollment)
        {
            var updateEnrollment = await _context.Enrollments.FindAsync(enrollment.StudentId, enrollment.CourseId);
        
            if (updateEnrollment is null)
                return null;

            updateEnrollment.EnrollmentDate = enrollment.EnrollmentDate;
            updateEnrollment.Grade = enrollment.Grade;

             await _context.SaveChangesAsync();

            return updateEnrollment;

        }

        public async Task<bool> DeleteEnrollmentByAsync(Enrollment enrollment)
        {
            var deleteEnrollment = await _context.Enrollments.FindAsync(enrollment.StudentId, enrollment.CourseId);
            if (deleteEnrollment is null)
                return false;


            _context.Enrollments.Remove(deleteEnrollment);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetStudentsByCourseAsync(int courseId)
        {
            var courseid = await _context.Courses.FindAsync(courseId);
            if (courseid is null)
                return null;

            return await _context.Enrollments.AsNoTracking()
                .Where(e => e.CourseId == courseId)
                .Select(e => e.Student).ToListAsync();
        }
        public async Task<List<Enrollment>> GetCoursesByStudentAsync(int studnetId)
        {
            
            return await _context.Enrollments                       
                .AsNoTracking()
                .Include(e => e.Course)
                .Where(e => e.StudentId == studnetId)
                .ToListAsync();
        }
        public async Task<double?> GetAverageGradePerCourseAsync(int courseId)
        {
            return await _context.Enrollments
                .AsNoTracking()
                .Where(e => e.CourseId == courseId)
                .Select(e => e.Grade)
                .AverageAsync();
        }
    }
}
