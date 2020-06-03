using EDU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Domain.Users
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<User> Get(int userId);
        Task<User> Get(string userName);
        Task<bool> Create(string username, string password, string email);
        Task<bool> Remove(int userId);
        Task<bool> Update(User updateUser);
        Task<bool> ChangeRole(int userId, IList<int> rolesId);
        Task<bool> ChangeRole(int userId, string[] rolesNames);
    }
}
