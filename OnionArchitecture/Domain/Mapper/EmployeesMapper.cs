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
    public class EmployeesMapper : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmpId)
               .HasName("pk_EmpId");

            builder.Property(e => e.EmpId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Employee Id")
                .HasColumnType("INT");
                

            builder.Property(e => e.EmpName)
                
                .HasColumnName("Employee Name")
                .HasColumnType("Varchar(50)")
                .IsRequired();

            builder.Property(e => e.City)
               
                .HasColumnName("Employee Location")
                .HasColumnType("Varchar(100)")
                .IsRequired();
        }
        
    }
}
