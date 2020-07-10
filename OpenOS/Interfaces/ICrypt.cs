using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Interfaces
{
    public interface ICrypt
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
