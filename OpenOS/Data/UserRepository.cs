using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenOS.Interfaces;
using OpenOS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class UserRepository : IUserRepository
    {
        protected readonly OpenOSContext _context;
        private readonly ICrypt _crypt;

        public UserRepository(OpenOSContext context, ICrypt crypt)
        {
            _context = context;
            _crypt = crypt;
        }

        public Task<int> Create(User user)
        {
            var encriptedPassword = _crypt.Encrypt(user.Password);
            user.Password = encriptedPassword;
            _context.Users.AddAsync(user);
            var result = _context.SaveChangesAsync();
            return result;
        }

        public Task<List<User>> GetAll()
        {
            return _context.Users.OrderByDescending(x => x.Id).ToListAsync();
        }

        public Task<User> GetByEmail(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public ValueTask<User> GetById(int id)
        {
            return _context.Users.FindAsync(id);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
