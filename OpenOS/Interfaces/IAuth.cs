using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface IAuth
    {
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
