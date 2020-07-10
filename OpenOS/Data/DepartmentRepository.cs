using Microsoft.EntityFrameworkCore;
using OpenOS.Interfaces;
using OpenOS.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly OpenOSContext _context;

        public DepartmentRepository(OpenOSContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Department department)
        {
            _context.Departments.Add(department);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAll()
        {
            return await _context.Departments.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async ValueTask<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<int> Remove(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            _context.Departments.Attach(department);
            _context.Departments.Remove(department);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Department departmentt)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Name = departmentt.Name;
                _context.Departments.Update(result);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
