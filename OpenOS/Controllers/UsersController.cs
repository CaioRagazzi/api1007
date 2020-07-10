using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await _userRepository.Create(user);

                return CreatedAtRoute(nameof(GetUserById), new { userId = user.Id }, user);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException.Message);
            }
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<ActionResult> GetUserById(int userId)
        {
            try
            {
                User user = await _userRepository.GetById(userId);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
