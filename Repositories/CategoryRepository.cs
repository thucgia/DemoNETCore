using Demo.Data;
using Demo.IReposotories;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category obj)
        {
            try
            {
                var category = _context.Add(obj);
                await _context.SaveChangesAsync();
                return category.Entity;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(Category obj)
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

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var categories = _context.tblCategories.ToList();
                return categories;
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
                var category = _context.tblCategories.FirstOrDefault(x => x.Id == id);
                return category;
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
