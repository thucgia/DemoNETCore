using Demo.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IServices
{
    public interface IBaseService<T>
    {
        public Task<T> Create(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public IEnumerable<T> GetAll();
        public T GetId(int id);
    }
}
