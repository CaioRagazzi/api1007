using OpenOS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface IUserRepository
    {
        ValueTask<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        void Update(User user);
        void Remove(User user);
    }
}
