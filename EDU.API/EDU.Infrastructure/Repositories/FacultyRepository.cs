using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Infrastructure.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDbContext context;

        public FacultyRepository(ApplicationDbContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<int> Create(string title, User head, User subhead)
        {
            var _h = await GetUser(head.Id);
            var _s = await GetUser(subhead.Id);
            var faculty = new Faculty() { Head = _h, Subhead = _s, Title = title };
            await context.Faculties.AddAsync(faculty);
            await context.SaveChangesAsync();

            return faculty.Id;
        }

        public async Task<List<Faculty>> Get() => await context.Faculties.ToListAsync();

        public async Task<Faculty> Get(int id) => 
            await context.Faculties.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<bool> Remove(int facultyId)
        {
            var faculty = await Get(facultyId);
            context.Faculties.Remove(faculty);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> Update(Faculty faculty)
        {
            var _f = await Get(faculty.Id);
            _f.Head = faculty.Head;
            _f.Subhead = faculty.Subhead;
            _f.Title = faculty.Title;

            context.Entry(_f).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        // TODO: separate to service
        private async Task<User> GetUser(int id) =>
            await context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }
}
