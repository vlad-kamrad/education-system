using EDU.Domain.Entities;
using EDU.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EDU.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        // TODO: Add documentation
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<EducationalCourse> EducationalCourses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DepartamentDisciplines> DepartamentDisciplines { get; set; }
        public virtual DbSet<DepartamentGroups> DepartamentGroups { get; set; }
        public virtual DbSet<DepartmentSemesters> DepartmentSemesters { get; set; }
        public virtual DbSet<EducationalCourseGroups> EducationalCourseGroups { get; set; }
        public virtual DbSet<EducationalCourseLessons> EducationalCourseLessons { get; set; }
        public virtual DbSet<ExamResults> ExamResults { get; set; }
        public virtual DbSet<FacultyDepartments> FacultyDepartments { get; set; }
        public virtual DbSet<GroupStudents> GroupStudents { get; set; }
        public virtual DbSet<SemesterEducationalCourses> SemesterEducationalCourses { get; set; }
        public virtual DbSet<SemesterExams> SemesterExams { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedDefaultData(builder);
            base.OnModelCreating(builder);
        }

        private void SeedDefaultData(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "SSU",
                Email = "superuser@super.user",
            });

            builder.Entity<Role>().HasData(new Role[] {
                new Role { Id = 1, Name = Domain.Common.Roles.SU },
                new Role { Id = 2, Name = Domain.Common.Roles.Admin },
                new Role { Id = 3, Name = Domain.Common.Roles.Student },
                new Role { Id = 4, Name = Domain.Common.Roles.Teacher },
            });

            builder.Entity<UserRole>().HasData(new { Id = 1, UserId = 1, RoleId = 1 });
            builder.Entity<UserRole>().HasData(new { Id = 2, UserId = 1, RoleId = 2 });
            builder.Entity<UserRole>().HasData(new { Id = 3, UserId = 1, RoleId = 3 });
            builder.Entity<UserRole>().HasData(new { Id = 4, UserId = 1, RoleId = 4 });
        }
    }
}
