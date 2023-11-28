using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public class StudentMapper : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id)
                .HasName("pk_StudId");

            builder.Property(s => s.Id)
                .HasColumnName("Student Id")
                .HasColumnType("INT");
            builder.Property(s => s.StudentName)
                .HasColumnName("Student Name")
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(s => s.City)
                .HasColumnName("Student Locatin")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(s => s.DateOfBirth)
                .HasColumnName("Date Of Birth");
            builder.Property(s => s.Gender)
                .HasColumnName("Gender")
                .HasColumnType("varchar(10)");
            builder.Property(s=>s.Contactno)
                .HasColumnName("Contact no")
                .HasColumnType("varchar(15)")
                .IsRequired();
            builder.Property(s => s.Picture)
                .HasColumnName("picture");
        }
    }
}
