using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenOS.Interfaces;
using OpenOS.Models;

namespace OpenOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketTypesController : ControllerBase
    {
        private ITicketTypeRepository _ticketTypeRepository;

        public TicketTypesController(ITicketTypeRepository ticketType)
        {
            _ticketTypeRepository = ticketType;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketType ticketType)
        {
            try
            {
                var response = await _ticketTypeRepository.Create(ticketType);

                if (response > 0)
                {
                    return CreatedAtRoute(nameof(GetTicketById), new { ticketTypeId = ticketType.Id }, ticketType);
                }
                else
                {
                    return NoContent();
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
                var ticketTypes = await _ticketTypeRepository.GetAll();

                if (ticketTypes != null)
                {
                    return Ok(ticketTypes);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpGet("{ticketTypeId}", Name = "GetTicketById")]
        public async Task<ActionResult> GetTicketById(int ticketTypeId)
        {
            try
            {
                var ticketType = await _ticketTypeRepository.GetById(ticketTypeId);

                if (ticketType != null)
                {
                    return Ok(ticketType);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TicketType ticketType)
        {
            try
            {
                var response = await _ticketTypeRepository.Update(id, ticketType);

                if (response > 0)
                {
                    return Ok(new { message = "Ticket type updated!" });
                }
                else
                {
                    return NotFound(new { message = "Ticket type not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _ticketTypeRepository.Remove(id);
                if (response > 0)
                {
                    return Ok(new { message = "Ticket deleted!" });
                }
                else
                {
                    return NotFound(new { message = "Ticket not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
