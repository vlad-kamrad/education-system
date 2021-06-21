using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using EDU.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Infrastructure.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly ApplicationDbContext context;

        public SemesterRepository(ApplicationDbContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> AddEducationCourse(int courseId, int semesterId)
        {
            var semester = await Get(semesterId);
            var course = await GetEducationCourse(courseId);
            await context.AddAsync(new SemesterEducationalCourses() { EducationalCourse = course, Semester = semester });
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> AddExam(Exam exam, int semesterId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(Semester semester)
        {
            await context.Semesters.AddAsync(semester);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateEducationCourse(EducationalCourse course)
        {
            await context.EducationalCourses.AddAsync(course);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Semester>> Get() => 
            await context.Semesters.ToListAsync();

        public async Task<Semester> Get(int semesterId) =>
            await context.Semesters.SingleOrDefaultAsync(x => x.Id == semesterId);

        private async Task<EducationalCourse> GetEducationCourse(int courseId) =>
            await context.EducationalCourses.SingleOrDefaultAsync(x => x.Id == courseId);

        public async Task<bool> Remove(int semesterId)
        {
            var semester = await Get(semesterId);
            context.Remove(semester);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> Update(Semester semester)
        {
            var _semester = await Get(semester.Id);
            _semester.StartDate = semester.StartDate;
            _semester.EndDate = semester.EndDate;
            context.Entry(_semester).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }
    }
}
