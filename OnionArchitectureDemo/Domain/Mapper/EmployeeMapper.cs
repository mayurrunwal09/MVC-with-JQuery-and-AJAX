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
    public class EmployeeMapper : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id)
                 .HasName("pk_Emp_Id");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Employee Id")
                .HasColumnType("INT");

            builder.Property(e => e.EmpName)
                .HasColumnName("Employee Name")
                .HasColumnType("Varchar(100)")
                .IsRequired();

            builder.Property(e=>e.Location)
                .HasColumnName("Employee Location")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.EmpPicture)
                .HasColumnName("Picture")
                .HasColumnType("varchar(200)");

            builder.Property(e => e.DateOfJoining)
                .HasColumnName("Date Of Joining");
                

        }
    }
}
