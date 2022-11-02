using Demo.IReposotories;
using Demo.IServices;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class ProductService:IBaseService<Product>, ICategoryService, ISupplierService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Supplier> _supplierRepository;
        public ProductService(IBaseRepository<Product> repository, IBaseRepository<Category> categoryRepository, IBaseRepository<Supplier> supplierRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public Task<Product> Create(Product obj)
        {
            try
            {
                if (obj == null) return null;
                var product = _repository.Create(obj);
                return product;
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
                var product = _repository.GetAll().FirstOrDefault(x => x.Id == id);
                if (product == null) throw new KeyNotFoundException("Category not existed");
                _repository.Delete(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetId(int id)
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

        public void Update(Product obj)
        {
            try
            {
                _repository.Update(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Category getCategoryById(int id)
        {
            try
            {
                return _categoryRepository.GetId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Supplier GetSupplierById(int id)
        {
            try
            {
                return _supplierRepository.GetId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
