using Demo.Models;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IReposotories
{
    public interface IAuthRepository
    {
        Task<User> Register(UserRegisterVM obj);
        User Authenticate(UserLoginVM obj);
    }
}
