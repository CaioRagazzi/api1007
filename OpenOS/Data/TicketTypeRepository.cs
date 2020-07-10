using Microsoft.EntityFrameworkCore;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private OpenOSContext _context;

        public TicketTypeRepository(OpenOSContext context)
        {
            _context = context;
        }
        public Task<int> Create(TicketType ticketType)
        {
            _context.TicketTypes.AddAsync(ticketType);
            return _context.SaveChangesAsync();
        }

        public Task<List<TicketType>> GetAll()
        {
            return _context.TicketTypes.OrderByDescending(x => x.Id).ToListAsync();
        }

        public ValueTask<TicketType> GetById(int id)
        {
            return _context.TicketTypes.FindAsync(id);
        }

        public async Task<int> Remove(int id)
        {
            var ticketType = await _context.TicketTypes.FirstOrDefaultAsync(x => x.Id == id);
            _context.TicketTypes.Attach(ticketType);
            _context.TicketTypes.Remove(ticketType);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int id, TicketType ticketType)
        {
            var result = await _context.TicketTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Name = ticketType.Name;
                _context.TicketTypes.Update(result);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
