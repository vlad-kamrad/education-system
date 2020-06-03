using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Application
{
    public interface IAuthService
    {
        Task<string> GenerateAccessToken(string userName, string password);
        Task<string> GenerateRefrershToken(string refreshToken, string userId);
    }
}
