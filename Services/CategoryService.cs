using Demo.IReposotories;
using Demo.IServices;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class CategoryService : IBaseService<Category>
    {
        private readonly IBaseRepository<Category> _repository;
        public CategoryService(IBaseRepository<Category> repository) {
            _repository = repository;
        }
        public Task<Category> Create(Category obj)
        {
            try
            {
                if (obj == null) return null;
                return _repository.Create(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var category = _repository.GetAll().FirstOrDefault(x => x.Id == id);
                if (category == null) throw new KeyNotFoundException("Category not existed");
                _repository.Delete(category);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<Category> GetAll()
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

        public Category GetId(int id)
        {
            try
            {
                return _repository.GetId(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Update(Category obj)
        {
            try
            {
                _repository.Update(obj);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
