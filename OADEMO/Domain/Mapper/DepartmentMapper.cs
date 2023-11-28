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
    public class DepartmentMapper : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_DepId");
            builder.Property(d => d.Id)
                .HasColumnName("Department Id")
                .HasColumnType("INT");
            builder.Property(d => d.DepName)
                .HasColumnName("Department Name")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
