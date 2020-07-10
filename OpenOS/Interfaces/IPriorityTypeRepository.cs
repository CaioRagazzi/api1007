using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface IPriorityTypeRepository
    {
        ValueTask<PriorityType> GetById(int id);
        Task<List<PriorityType>> GetAll();
        Task<int> Create(PriorityType priorityType);
        Task<int> Update(int id, PriorityType priorityType);
        Task<int> Remove(int id);
    }
}
