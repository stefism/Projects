﻿// <auto-generated />
using System;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDemo_DBFirst.Migrations
{
    [DbContext(typeof(SoftUniContext))]
    partial class SoftUniContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreDemo.Models.Addresses", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressText")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("TownId")
                        .HasColumnName("TownID")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EFCoreDemo.Models.DeletedEmployees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Deleted___7AD04FF1237A1BD0");

                    b.ToTable("Deleted_Employees");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EFCoreDemo.Models.EmplWithSalaryMore30000", b =>
                {
                    b.Property<int?>("AddressId")
                        .HasColumnName("AddressID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.ToTable("Empl_With_Salary_More_30000");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnName("AddressID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnName("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AddressId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EFCoreDemo.Models.EmployeesProjects", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeesProjects");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProjectID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Towns", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TownID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("TownId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Towns2", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TownID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("TownId")
                        .HasName("PK_Taowns");

                    b.ToTable("Towns2");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Addresses", b =>
                {
                    b.HasOne("EFCoreDemo.Models.Towns", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .HasConstraintName("FK_Addresses_Towns");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Departments", b =>
                {
                    b.HasOne("EFCoreDemo.Models.Employees", "Manager")
                        .WithMany("Departments")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK_Departments_Employees");
                });

            modelBuilder.Entity("EFCoreDemo.Models.Employees", b =>
                {
                    b.HasOne("EFCoreDemo.Models.Addresses", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Employees_Addresses");

                    b.HasOne("EFCoreDemo.Models.Departments", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Employees_Departments")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreDemo.Models.Employees", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK_Employees_Employees");
                });

            modelBuilder.Entity("EFCoreDemo.Models.EmployeesProjects", b =>
                {
                    b.HasOne("EFCoreDemo.Models.Employees", "Employee")
                        .WithMany("EmployeesProjects")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_EmployeesProjects_Employees")
                        .IsRequired();

                    b.HasOne("EFCoreDemo.Models.Projects", "Project")
                        .WithMany("EmployeesProjects")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_EmployeesProjects_Projects")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}