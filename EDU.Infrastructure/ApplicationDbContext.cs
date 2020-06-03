using EDU.Domain.Entities;
using EDU.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EDU.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        // TODO: Add documentation
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<EducationalCourse> EducationalCourses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DepartamentDisciplines> DepartamentDisciplines { get; set; }
        public DbSet<DepartamentGroups> DepartamentGroups { get; set; }
        public DbSet<DepartmentSemesters> DepartmentSemesters { get; set; }
        public DbSet<EducationalCourseGroups> EducationalCourseGroups { get; set; }
        public DbSet<EducationalCourseLessons> EducationalCourseLessons { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        public DbSet<FacultyDepartments> FacultyDepartments { get; set; }
        public DbSet<GroupStudents> GroupStudents { get; set; }
        public DbSet<SemesterEducationalCourses> SemesterEducationalCourses { get; set; }
        public DbSet<SemesterExams> SemesterExams { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

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
