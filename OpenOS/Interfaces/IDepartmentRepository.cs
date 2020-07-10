using OpenOS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface IDepartmentRepository
    {
        ValueTask<Department> GetById(int id);
        Task<List<Department>> GetAll();
        Task<int> Create(Department department);
        Task<int> Update(int id, Department departmentt);
        Task<int> Remove(int id);
    }
}
