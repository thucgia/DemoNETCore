using Demo.Data;
using Demo.IReposotories;
using Demo.Models;
using Demo.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(UserRegisterVM obj)
        {
            try
            {
                byte[] PasswordHash, PasswordSalt;

                CreatePasswordHash(obj.Password, out PasswordHash, out PasswordSalt);

                User user = new User
                {
                    UserName = obj.UserName,
                    Email = obj.Email,
                    PasswordHash = PasswordHash,
                    PasswordSalt = PasswordSalt,
                    PhoneNumber = obj.PhoneNumber
                };

                var result = _context.Add(user);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Authenticate(UserLoginVM obj)
        {
            var user = _context.tblUsers.FirstOrDefault(x => x.UserName == obj.Username);

            if (user == null) return null;

            if (VerifyPassword(obj.Password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }
            return null;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i<computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
    }
}
