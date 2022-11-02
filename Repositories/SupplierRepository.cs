using Demo.Data;
using Demo.IReposotories;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class SupplierRepository : IBaseRepository<Supplier>
    {
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> Create(Supplier obj)
        {
            try
            {
                var supplier = _context.Add(obj);
                await _context.SaveChangesAsync();
                return supplier.Entity;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(Supplier obj)
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

        public IEnumerable<Supplier> GetAll()
        {
            try
            {
                var supplier = _context.tblSuppliers.ToList();
                return supplier;
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
                var supplier = _context.tblSuppliers.FirstOrDefault(x => x.Id == id);
                return supplier;
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
                _context.Attach(obj);
                _context.Entry(obj).Property(x => x.Name).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
