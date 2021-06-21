using EDU.Application;

namespace EDU.Infrastructure.Services
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string EncodePassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);
        public bool ValidatePassword(string password, string hash) =>
            BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
