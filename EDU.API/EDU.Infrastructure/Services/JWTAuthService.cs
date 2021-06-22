using EDU.Application;
using EDU.Domain.Entities;
using EDU.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Infrastructure.Services
{
    public class JWTAuthService : IAuthService
    {
        private readonly IOptions<TokenSettings> configurations;
        private readonly IUserRepository userRepository;
        private readonly ApplicationDbContext context;
        private readonly IPasswordHasher passwordHasher;

        public JWTAuthService(IUserRepository userRepository, ApplicationDbContext context, IPasswordHasher passwordHasher, IOptions<TokenSettings> configurations)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.configurations = configurations;
            this.passwordHasher = passwordHasher;
        }

        public async Task<string> GenerateAccessToken(string userName, string password)
        {
            User user = await userRepository.Get(userName);
            if (!await CheckPassword(user.Id, password)) { return null; }
            return await CombinateResult(userName, user.Id);
        }

        private async Task<bool> CheckPassword(int userId, string password)
        {
            User user = await userRepository.Get(userId);
            return passwordHasher.ValidatePassword(password, user.Password); // TODO: Change to async
        }

        public async Task<string> GenerateRefrershToken(string refreshToken, string userName)
        {
            throw new NotImplementedException();
        }

        // Set params
        private async Task<SecurityTokenDescriptor> GetSecurityTokenDescriptor(int userId, string username)
        {
            return new SecurityTokenDescriptor
            {
                Subject = await CreateClaimsIdentity(userId, username),
                Audience = configurations.Value.Audience,
                Issuer = configurations.Value.Issuer,
                Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(configurations.Value.LifeTimeAccess)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configurations.Value.IssuerSigningKey)), SecurityAlgorithms.HmacSha256)
            };
        }

        private async Task<ClaimsIdentity> CreateClaimsIdentity(int userId, string username)
        {
            var claimsRoles = await GetUserRoles(userId);
            var _ = claimsRoles.Select(x => new Claim(ClaimTypes.Role, x.Name));
            var claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, username) };
            claims.AddRange(_);
            var a = new ClaimsIdentity(claims);
            return a;
        }

        // Combinate result with access tokens, user id/name and expiration time
        private string GenerateTokenResponse(
            JwtSecurityTokenHandler tokenHandler,
            SecurityToken token,
            string userName,
            List<string> roles)
        {
            // TODO: use const seconds
            return JsonConvert.SerializeObject(new SerializeTokenObject
            {
                AccessToken = tokenHandler.WriteToken(token),
                TokenExpiration = token.ValidTo,
                UserName = userName,
                Roles = roles
            });
        }

        // Invoke all helper functions and transform to JSON 
        private async Task<string> CombinateResult(string userName, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = await GetSecurityTokenDescriptor(userId, userName);
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var userRoles = await GetUserRoles(userId);
            var _ = userRoles.Select(x => x.Name).ToList();
            return GenerateTokenResponse(tokenHandler, token, userName, _);
        }

        // TODO: Separate to service
        private async Task<List<Role>> GetUserRoles(int userId) =>
            await context.UserRoles.Where(x => x.User.Id == userId).Select(x => x.Role).ToListAsync();

        private class SerializeTokenObject
        {
            public string AccessToken { get; set; }
            public DateTime TokenExpiration { get; set; }
            public string UserName { get; set; }
            public List<string> Roles { get; set; }
        }
    }
}
