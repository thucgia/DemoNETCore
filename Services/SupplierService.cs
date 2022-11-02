using Demo.IReposotories;
using Demo.IServices;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class SupplierService : IBaseService<Supplier>
    {
        private readonly IBaseRepository<Supplier> _repository;
        public SupplierService(IBaseRepository<Supplier> repository) {
            _repository = repository;
        }

        public Task<Supplier> Create(Supplier obj)
        {
            try
            {
                if (obj == null) return null;
                return _repository.Create(obj);
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
                var supplier = _repository.GetAll().FirstOrDefault(x => x.Id == id);
                if (supplier == null) throw new KeyNotFoundException("Supplier not existed");
                _repository.Delete(supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Supplier> GetAll()
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

        public Supplier GetId(int id)
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

        public void Update(Supplier obj)
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
    }
}
