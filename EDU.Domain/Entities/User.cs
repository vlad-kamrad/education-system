using EDU.Domain.ValueObjects;
using System.Collections.Generic;

namespace EDU.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
