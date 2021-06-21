using EDU.Domain.Common;
using EDU.Domain.Entities;
using EDU.Domain.Users;
using EDU.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDU.Infrastructure.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> ChangeRole(int userId, IList<int> rolesId)
        {
            var roleNames = context.Roles
                .Where(x => rolesId.Contains(x.Id))
                .Select(x => x.Name)
                .ToArray();
            return await ChangeRole(userId, roleNames);
        }

        public async Task<bool> ChangeRole(int userId, string[] rolesNames)
        {
            try
            {
                var user = await Get(userId);

                var _ = context.UserRoles.Where(x => x.User.Id == userId);
                var userRoles = _.Select(x => x.Role.Name);
                var desiredRoles = rolesNames.ToList();

                var toRemove = userRoles.Where(x => !desiredRoles.Contains(x));
                var toAdd = desiredRoles.Where(x => !userRoles.Contains(x));

                foreach (var role in toRemove) await RemoveRole(userId, role);
                foreach (var role in toAdd) await AddRole(userId, role);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Create(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = password
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var role = await context.Roles.SingleAsync(x => x.Name == Roles.Student);

            await context.UserRoles.AddAsync(new UserRole() { User = user, Role = role });
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<User>> Get() => await context.Users.ToListAsync();

        public async Task<User> Get(int userId) =>
            await context.Users.SingleOrDefaultAsync(x => x.Id == userId);

        public async Task<User> Get(string userName) =>
            await context.Users.SingleOrDefaultAsync(x => x.Username == userName);

        public async Task<User> GetUser(int userId) =>
            await context.Users.SingleOrDefaultAsync(x => x.Id == userId);

        public async Task<bool> Remove(int userId)
        {
            var user = await Get(userId);
            context.Users.Remove(user);
            context.SaveChanges();

            return true;
        }

        public async Task<bool> Update(User updateUser)
        {
            var user = await Get(updateUser.Id);
            user.Username = updateUser.Username;
            user.Password = updateUser.Password;
            user.Email = updateUser.Email;
            context.Entry(user).State = EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        private async Task<bool> RemoveRole(int userId, string roleName)
        {
            try
            {
                var userRole = await context.UserRoles
                    .SingleOrDefaultAsync(x => x.User.Id == userId && x.Role.Name == roleName);

                context.UserRoles.Remove(userRole);
                await context.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                return false;
            }
            return true;
        }

        private async Task<bool> AddRole(int userId, string roleName)
        {
            User user = await context.Users.SingleOrDefaultAsync(x => x.Id == userId);

            var isCurrentRole = await context.UserRoles
                .SingleOrDefaultAsync(x => x.User.Id == userId && x.Role.Name == roleName);

            if (isCurrentRole != null) return false;

            var role = await context.Roles.SingleOrDefaultAsync(x => x.Name == roleName);

            context.UserRoles.Add(new UserRole
            {
                User = user,
                Role = role
            });

            await context.SaveChangesAsync();

            return true;
        }
    }
}
