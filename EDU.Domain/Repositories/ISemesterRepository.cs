using EDU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Domain.Repositories
{
    public interface ISemesterRepository
    {
        Task<List<Semester>> Get();
        Task<Semester> Get(int semesterId);
        Task<bool> Create(Semester semester);
        Task<bool> Remove(int semesterId);
        Task<bool> Update(Semester semester);
        Task<bool> AddExam(Exam exam, int semesterId);
        Task<bool> AddEducationCourse(int courseId, int semesterId);
        Task<bool> CreateEducationCourse(EducationalCourse course);
    }
}
