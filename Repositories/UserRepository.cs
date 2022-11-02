using Demo.Data;
using Demo.IReposotories;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User obj)
        {
            try
            {
                if (obj != null)
                {
                    var user = _context.Add<User>(obj);
                    await _context.SaveChangesAsync();
                    return user.Entity;
                }
                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Update(User obj)
        {
            try
            {
                _context.Attach(obj);
                _context.Entry(obj).Property(item => item.Email).IsModified = true;
                _context.Entry(obj).Property(item => item.PhoneNumber).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(User obj)
        {
            try
            {
                _context.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                var users = _context.tblUsers.ToList();
                if (users == null) return null;
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User GetId(int id)
        {
            try
            {
                var user = _context.tblUsers.FirstOrDefault(x => x.Id == id);
                return user;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
