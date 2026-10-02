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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(c => new { c.StudentId, c.CourseId });

            builder.Property(c => c.EnrollmentDate).HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.Grade).HasColumnType("INT")
                .IsRequired(false);


            builder.HasOne(e => e.Course).WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.CourseId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Student).WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.StudentId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedData.LoadEnrollments());

            builder.ToTable("Enrollments");
        }
    }
}
