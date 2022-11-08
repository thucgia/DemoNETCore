using Demo.Commons;
using Demo.IReposotories;
using Demo.IServices;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class UserService : IBaseService<User>
    {
        private readonly IBaseRepository<User> _repository;
        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public void Update(User obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("No user");
                _repository.Update(obj);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var user = _repository.GetAll().FirstOrDefault(x => x.Id == id);
                if (user == null) throw new ArgumentException("User not Found");
                _repository.Delete(user);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public User GetId(int id)
        {
            try
            {
                return _repository.GetId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<User> Create(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
