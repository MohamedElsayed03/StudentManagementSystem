using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.StudentId);
            builder.Property(c => c.StudentId).ValueGeneratedNever();

            builder.Property(c => c.FullName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnType("VARCHAR")
                  .HasMaxLength(50).IsRequired();
          
            builder.HasIndex(c => c.Email)
                .IsUnique();


            builder.Property(c => c.DateOfBirth)
                   .HasColumnType("date")
                  .IsRequired();


            builder.Property(c => c.EnrollmentDate).HasColumnType("date")
                 .IsRequired();

            builder.HasData(SeedData.LoadStudents());

            builder.ToTable("Students");
        }
    }
}
