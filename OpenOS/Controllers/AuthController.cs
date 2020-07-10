using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Threading.Tasks;

namespace OpenOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IAuth authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] Auth auth)
        {
            try
            {
                var userModel = await _authRepository.GetByEmailAndPassword(auth.Email, auth.Password);

                if (userModel == null)
                {
                    return NotFound(new { message = "Invalid user or password." });
                }

                var token = _tokenService.GenerateToken(auth);

                return Ok(new
                {
                    user = userModel,
                    token
                });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
