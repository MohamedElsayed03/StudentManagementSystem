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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(e => e.InstructorId);
            builder.Property(x => x.InstructorId).ValueGeneratedNever();

            builder.Property(e => e.FullName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.HasData(SeedData.LoadInstructors());

            builder.ToTable("Instuctors");
        }
    }
}
