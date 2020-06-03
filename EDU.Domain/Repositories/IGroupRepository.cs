using EDU.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDU.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<List<Group>> Get();
        Task<Group> Get(int groupId);
        Task<bool> Create(string title, User Curator, User HeadMan);
        Task<bool> Remove(int groupId);
        Task<bool> Update(Group group);
        Task<bool> AddStudent(int groupId, int studentId);
        Task<bool> RemoveStudent(int groupId, int studentId);
    }
}
