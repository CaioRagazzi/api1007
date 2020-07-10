using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface ITicketTypeRepository
    {
        ValueTask<TicketType> GetById(int id);
        Task<List<TicketType>> GetAll();
        Task<int> Create(TicketType ticketType);
        Task<int> Update(int id, TicketType ticketType);
        Task<int> Remove(int id);
    }
}
