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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.CourseId);
            builder.Property(x => x.CourseId).ValueGeneratedNever();

            builder.Property(c => c.Title).HasColumnType("VARCHAR")
                .HasMaxLength(100).IsRequired();

            builder.Property(c => c.Credits).IsRequired();

            builder.Property(c => c.Description).HasColumnType("VARCHAR")
                .HasMaxLength(200).IsRequired();

            builder.HasOne(c => c.Instructor)
          .WithMany(i => i.Courses)
          .HasForeignKey(c => c.InstructorId)
          .IsRequired(false);

            builder.HasData(SeedData.LoadCourses());

            builder.ToTable("Courses");

        }
    }
}
