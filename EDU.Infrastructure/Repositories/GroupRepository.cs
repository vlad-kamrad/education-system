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
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext context;

        public GroupRepository(ApplicationDbContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> AddStudent(int groupId, int studentId)
        {
            var group = await Get(groupId);
            var student = await context.Users.SingleOrDefaultAsync(x => x.Id == studentId);
            await context.GroupStudents.AddAsync(new GroupStudents() { Group = group, Student = student });
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Create(string title, User Curator, User HeadMan)
        {
            var _c = await GetUser(Curator.Id);
            var _h = await GetUser(HeadMan.Id);
            await context.Groups.AddAsync(new Group() { Title = title, Curator = _c, HeadMan = _h, IsActive = true });
            return true;
        }

        public async Task<List<Group>> Get() => await context.Groups.ToListAsync();

        public async Task<Group> Get(int groupId) => 
            await context.Groups.SingleOrDefaultAsync(x => x.Id == groupId);

        public async Task<bool> Remove(int groupId)
        {
            var group = await Get(groupId);
            context.Groups.Remove(group);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveStudent(int groupId, int studentId)
        {
            var _ = await context.GroupStudents
                .SingleOrDefaultAsync(x => x.Group.Id == groupId && x.Student.Id == studentId);
            context.GroupStudents.Remove(_);
            return true;
        }

        public async Task<bool> Update(Group group)
        {
            var _group = await Get(group.Id);
            _group.IsActive = group.IsActive;
            _group.HeadMan = group.HeadMan;
            _group.Title = group.Title;
            _group.Curator = group.Curator;

            context.Entry(_group).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        // TODO: separate to service
        private async Task<User> GetUser(int id) =>
            await context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }
}
