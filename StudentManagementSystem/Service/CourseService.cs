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
    public class CourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);

            await _context.SaveChangesAsync();
        }


        public async Task<Course?> GetCoursetById(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<Course?> UpdateCourseByAsync(Course course)
        {
            var updatecourse = await _context.Courses.FindAsync(course.CourseId);
            if (updatecourse is null)             
                return null;
             
            updatecourse.CourseId = course.CourseId;
            updatecourse.Title = course.Title;
            updatecourse.Description = course.Description;
            updatecourse.Credits = course.Credits;


            await _context.SaveChangesAsync();

            return updatecourse;

        }

        public async Task<bool> DeleteCourseByAsync(Course course)
        {
            var deletecourse = await _context.Courses.FindAsync(course.CourseId);
            if (deletecourse is null)
                return false;


            _context.Courses.Remove(deletecourse);

            await _context.SaveChangesAsync();
            return true;
        } 
    }
}
