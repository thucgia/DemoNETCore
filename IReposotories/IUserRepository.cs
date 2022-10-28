using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IReposotories
{
    public interface IUserRepository<T>
    {
        public Task<T> Create(T obj);
        public void Update(T obj);
        public void Delete(T obj);
        //public T GetId(int id);
        public IEnumerable<T> GetAll();
    }
}
