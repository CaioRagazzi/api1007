using OpenOS.Models;

namespace OpenOS.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Auth auth);
    }
}
