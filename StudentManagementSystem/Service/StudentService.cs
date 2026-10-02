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
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();
        }


        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(c => c.StudentId == id);

        }

        public async Task<Student?> UpdateStudentByAsync(Student student)
        {
            var updatestudnet = await _context.Students.FindAsync(student.StudentId);
            if(updatestudnet is null)
            {
                return null;
            } 

            updatestudnet.FullName = student.FullName;
            updatestudnet.Email = student.Email;
            updatestudnet.DateOfBirth = student.DateOfBirth;
            updatestudnet.EnrollmentDate = student.EnrollmentDate;

            await _context.SaveChangesAsync();

            return updatestudnet;

        }

        public async Task<bool> DeleteStudentByAsync(Student student)
        {
            var deletestudent = await _context.Students.FindAsync(student.StudentId);
            if(deletestudent is null)          
                return false;
             

            _context.Students.Remove(deletestudent);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> SearchByNameAsync(string name)
        {
            return await _context.Students.AsNoTracking().Where(c => c.FullName.Contains(name)).ToListAsync();
             
        }

        public async Task<Student?> StudnetWithallEnrollmentsAsync(Student student)
        {
            var result = await _context.Students.AsNoTracking()
                .Include(c => c.Enrollments).FirstOrDefaultAsync(c => c.StudentId == student.StudentId);

            if(result is null)           
                return null;
            
            return result;
        }


    }
}
