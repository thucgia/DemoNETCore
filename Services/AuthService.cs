using Demo.IReposotories;
using Demo.IServices;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJWTManagerRepository _jwtManagerRepository;

        public AuthService(IAuthRepository authRepository, IJWTManagerRepository jwtManagerRepository)
        {
            _authRepository = authRepository;
            _jwtManagerRepository = jwtManagerRepository;
        }

        public string Authenticate(UserLoginVM obj)
        {
            var login = _authRepository.Authenticate(obj);

            if (login == null) return null;

            var token = _jwtManagerRepository.GenerateToken(login);

            return token.Token;
        }

        public async Task<string> Register(UserRegisterVM obj)
        {
            if (obj == null) return null;

            var user = await _authRepository.Register(obj);

            if (user != null) return _jwtManagerRepository.GenerateToken(user).Token;
            return null;
        }
    }
}
