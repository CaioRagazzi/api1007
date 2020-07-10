using Microsoft.EntityFrameworkCore;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Data
{
    public class AuthRepository : IAuth
    {
        protected readonly OpenOSContext _context;
        private readonly ICrypt _crypt;

        public AuthRepository(OpenOSContext context, ICrypt crypt)
        {
            _context = context;
            _crypt = crypt;
        }
        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            var encriptedPassword = _crypt.Encrypt(password);

            var users = await _context.Users.ToListAsync();

            var query = from user in users
                        where user.Email == email && user.Password == encriptedPassword
                        select user;

            return query.FirstOrDefault();
        }
    }
}
