using Microsoft.EntityFrameworkCore;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class PriorityTypeRepository : IPriorityTypeRepository
    {
        private OpenOSContext _context;

        public PriorityTypeRepository(OpenOSContext context)
        {
            _context = context;
        }

        public Task<int> Create(PriorityType priorityType)
        {
            _context.PriorityTypes.AddAsync(priorityType);
            return _context.SaveChangesAsync();
        }

        public Task<List<PriorityType>> GetAll()
        {
            return _context.PriorityTypes.OrderByDescending(x => x.Id).ToListAsync();
        }

        public ValueTask<PriorityType> GetById(int id)
        {
            return _context.PriorityTypes.FindAsync(id);
        }

        public async Task<int> Remove(int id)
        {
            var priorityType = await _context.PriorityTypes.FirstOrDefaultAsync(x => x.Id == id);
            _context.PriorityTypes.Attach(priorityType);
            _context.PriorityTypes.Remove(priorityType);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int id, PriorityType priorityType)
        {
            var result = await _context.PriorityTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Name = priorityType.Name;
                _context.PriorityTypes.Update(result);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
