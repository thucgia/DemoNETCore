using Demo.Data;
using Demo.IReposotories;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product obj)
        {
            try
            {
                var product = _context.Add(obj);
                await _context.SaveChangesAsync();
                return product.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Product obj)
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

        public IEnumerable<Product> GetAll()
        {
            try
            {
                var products = _context.tblProducts.ToList();
                return products;
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
                var product = _context.tblProducts.FirstOrDefault(x => x.Id == id);
                return product;
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
                _context.Attach(obj);
                _context.Entry(obj).Property(x => x.Name).IsModified = true;
                _context.Entry(obj).Property(x => x.Price).IsModified = true;
                _context.Entry(obj).Property(x => x.Quantity).IsModified = true;
                _context.Entry(obj).Property(x => x.Description).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
