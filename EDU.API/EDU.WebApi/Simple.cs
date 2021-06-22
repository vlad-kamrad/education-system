using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDU.WebApi
{
    public class Simple { }
    /*
    public class Role
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
    public class UserRole
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }

    // Кафедра
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Head { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Discipline> Disciplines { get; set; }
        public IList<Semester> Semesters { get; set; }
    }

    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Semester
    {
        // Maybe date
        public int Id { get; set; }
        public IList<Exam> Exams { get; set; }
        public IList <EducationalCourse> EducationalCourses { get; set; }
    }

    public class Exam
    {
        public int Id { get; set; }
        public User Examiner { get; set; }
        public Discipline Discipline { get; set; }
        public Group Group { get; set; }
        public IList<ExamResult> Results { get; set; }

    }

    public class ExamResult
    {
        public int Id { get; set; }
        public Exam Exam { get; set; }
        public User Student { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
    }

    public class EducationalCourse
    {
        public int Id { get; set; }
        public User Teacher { get; set; }
        public IList<Group> Groups { get; set; } // Занятия доступны для нескольких групп одновременно
        public IList<Lesson> Lessons { get; set; }
    }

    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IList<User> MissingList { get; set; }
    }

    public class Group
    {
        public User Curator { get; set; }
        public User HeadMan { get; set; }
        public IList<User> Students { get; set; }
        public bool IsActive { get; set; }
    }

    public class Faculty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Head { get; set; }
        public User Subhead { get; set; }
        public IList<Department> Departments { get; set; }
    }*/
}
