using System;
using System.Collections.Generic;
using System.Text;

namespace EDU.Application
{
    public interface IPasswordHasher
    {
        string EncodePassword(string password);
        bool ValidatePassword(string password, string hash);
    }
}
