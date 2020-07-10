using OpenOS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface ICategoryRepository
    {
        ValueTask<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<int> Create(Category category);
        Task<int> Update(int id, Category category);
        Task<int> Remove(int id);
    }
}
