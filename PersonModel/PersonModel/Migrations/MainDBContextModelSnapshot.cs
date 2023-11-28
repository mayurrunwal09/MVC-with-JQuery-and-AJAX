﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonModel.Models;

#nullable disable

namespace PersonModel.Migrations
{
    [DbContext(typeof(MainDBContext))]
    partial class MainDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonModel.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Contactno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PersonAge")
                        .HasColumnType("int");

                    b.Property<string>("personName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
