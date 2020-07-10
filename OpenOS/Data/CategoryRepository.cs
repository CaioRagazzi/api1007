using Microsoft.EntityFrameworkCore;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private OpenOSContext _context;

        public CategoryRepository(OpenOSContext context)
        {
            _context = context;
        }

        public Task<int> Create(Category category)
        {
            _context.Categories.AddAsync(category);
            return _context.SaveChangesAsync();
        }

        public Task<List<Category>> GetAll()
        {
            return _context.Categories.OrderByDescending(x => x.Id).ToListAsync();
        }

        public ValueTask<Category> GetById(int id)
        {
            return _context.Categories.FindAsync(id);
        }

        public async Task<int> Remove(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Categories.Attach(category) ;
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Category category)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Name = category.Name;
                _context.Categories.Update(result);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
