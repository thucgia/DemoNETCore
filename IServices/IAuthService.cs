using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IServices
{
    public interface IAuthService
    {
        string Authenticate(UserLoginVM obj);

        Task<string> Register(UserRegisterVM obj);
    }
}
