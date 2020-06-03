using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using EDU.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDU.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> Create(Department department)
        {
            try
            {
                await context.Departments.AddAsync(department);
                await context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<Department> GetDepartment(int departmentId) =>
            await context.Departments.SingleOrDefaultAsync(x => x.Id == departmentId);

        public async Task<List<Department>> GetDepartments() =>
            await context.Departments.ToListAsync();

        public async Task<Discipline> GetDiscipline(int disciplineId) =>
            await context.Disciplines.SingleOrDefaultAsync(x => x.Id == disciplineId);

        public async Task<bool> Remove(int departmentId)
        {
            var departament = await GetDepartment(departmentId);
            context.Departments.Remove(departament);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveDiscipline(int disciplineId)
        {
            var discipline = await GetDiscipline(disciplineId);
            var dd = context.DepartamentDisciplines.Where(x => x.Discipline.Id == disciplineId);
            foreach (var d in dd) context.DepartamentDisciplines.Remove(d);
            context.Disciplines.Remove(discipline);
            return true;
        }

        public async Task<bool> Update(Department department)
        {
            var _d = await GetDepartment(department.Id);
            _d.Head = department.Head;
            _d.Name = department.Name;
            context.Entry(_d).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public async Task<int> CreateDiscipline(int departmentId, string name, string description)
        {
            var discipline = new Discipline() { Description = description, Name = name };
            await context.Disciplines.AddAsync(discipline);
            await context.SaveChangesAsync();

            var department = await GetDepartment(departmentId);
            await context.DepartamentDisciplines.AddAsync(
                new DepartamentDisciplines() { Department = department, Discipline = discipline });
            await context.SaveChangesAsync();
            return discipline.Id;
        }
    }
}
