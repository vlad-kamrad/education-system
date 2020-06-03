using EDU.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDU.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<bool> Create(Department department);
        Task<bool> Remove(int departmentId);
        Task<bool> Update(Department department);
        Task<Discipline> GetDiscipline(int disciplineId);
        Task<int> CreateDiscipline(int departmentId, string name, string description);
        Task<bool> RemoveDiscipline(int disciplineId);
    }
}
