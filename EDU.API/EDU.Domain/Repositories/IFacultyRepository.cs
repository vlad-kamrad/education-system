using EDU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Domain.Repositories
{
    public interface IFacultyRepository
    {
        Task<List<Faculty>> Get();
        Task<Faculty> Get(int id);
        Task<int> Create(string title, User head, User subhead);
        Task<bool> Remove(int facultyId);
        Task<bool> Update(Faculty faculty);
    }
}
