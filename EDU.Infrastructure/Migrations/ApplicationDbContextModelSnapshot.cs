﻿// <auto-generated />
using System;
using EDU.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDU.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDU.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HeadId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeadId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("EDU.Domain.Entities.EducationalCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("EducationalCourses");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<int?>("ExaminerId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("ExaminerId");

                    b.HasIndex("GroupId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HeadId")
                        .HasColumnType("int");

                    b.Property<int?>("SubheadId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeadId");

                    b.HasIndex("SubheadId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CuratorId")
                        .HasColumnType("int");

                    b.Property<int?>("HeadManId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CuratorId");

                    b.HasIndex("HeadManId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SU"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Teacher"
                        });
                });

            modelBuilder.Entity("EDU.Domain.Entities.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("EDU.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "superuser@super.user",
                            Username = "SSU"
                        });
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartamentDisciplines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DisciplineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("DepartamentDisciplines");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartamentGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("GroupId");

                    b.ToTable("DepartamentGroups");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartmentSemesters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.ToTable("DepartmentSemesters");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.EducationalCourseGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalCourseId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationalCourseId");

                    b.HasIndex("GroupId");

                    b.ToTable("EducationalCourseGroups");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.EducationalCourseLessons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalCourseId")
                        .HasColumnType("int");

                    b.Property<int?>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationalCourseId");

                    b.HasIndex("LessonId");

                    b.ToTable("EducationalCourseLessons");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.ExamResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamResults");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.FacultyDepartments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("FacultyDepartments");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.GroupStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("GroupStudents");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.SemesterEducationalCourses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalCourseId")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationalCourseId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SemesterEducationalCourses");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.SemesterExams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SemesterExams");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            RoleId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            RoleId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EDU.Domain.Entities.Department", b =>
                {
                    b.HasOne("EDU.Domain.Entities.User", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");
                });

            modelBuilder.Entity("EDU.Domain.Entities.EducationalCourse", b =>
                {
                    b.HasOne("EDU.Domain.Entities.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Exam", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId");

                    b.HasOne("EDU.Domain.Entities.User", "Examiner")
                        .WithMany()
                        .HasForeignKey("ExaminerId");

                    b.HasOne("EDU.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Faculty", b =>
                {
                    b.HasOne("EDU.Domain.Entities.User", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");

                    b.HasOne("EDU.Domain.Entities.User", "Subhead")
                        .WithMany()
                        .HasForeignKey("SubheadId");
                });

            modelBuilder.Entity("EDU.Domain.Entities.Group", b =>
                {
                    b.HasOne("EDU.Domain.Entities.User", "Curator")
                        .WithMany()
                        .HasForeignKey("CuratorId");

                    b.HasOne("EDU.Domain.Entities.User", "HeadMan")
                        .WithMany()
                        .HasForeignKey("HeadManId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartamentDisciplines", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("EDU.Domain.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartamentGroups", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("EDU.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.DepartmentSemesters", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("EDU.Domain.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.EducationalCourseGroups", b =>
                {
                    b.HasOne("EDU.Domain.Entities.EducationalCourse", "EducationalCourse")
                        .WithMany()
                        .HasForeignKey("EducationalCourseId");

                    b.HasOne("EDU.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.EducationalCourseLessons", b =>
                {
                    b.HasOne("EDU.Domain.Entities.EducationalCourse", "EducationalCourse")
                        .WithMany()
                        .HasForeignKey("EducationalCourseId");

                    b.HasOne("EDU.Domain.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.ExamResults", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("EDU.Domain.Entities.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.FacultyDepartments", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("EDU.Domain.Entities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.GroupStudents", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("EDU.Domain.Entities.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.SemesterEducationalCourses", b =>
                {
                    b.HasOne("EDU.Domain.Entities.EducationalCourse", "EducationalCourse")
                        .WithMany()
                        .HasForeignKey("EducationalCourseId");

                    b.HasOne("EDU.Domain.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.SemesterExams", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("EDU.Domain.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("EDU.Domain.ValueObjects.UserRole", b =>
                {
                    b.HasOne("EDU.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("EDU.Domain.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
