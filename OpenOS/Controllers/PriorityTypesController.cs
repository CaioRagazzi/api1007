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
    public class PriorityTypesController : ControllerBase
    {
        private IPriorityTypeRepository _priorityTypeRepository;

        public PriorityTypesController(IPriorityTypeRepository priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PriorityType priorityType)
        {
            try
            {
                var response = await _priorityTypeRepository.Create(priorityType);

                if (response > 0)
                {
                    return CreatedAtRoute(nameof(GetPriorityById), new { priorityTypeId = priorityType.Id }, priorityType);
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
                var priorityTypes = await _priorityTypeRepository.GetAll();

                if (priorityTypes != null)
                {
                    return Ok(priorityTypes);
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

        [HttpGet("{priorityTypeId}", Name = "GetPriorityById")]
        public async Task<ActionResult> GetPriorityById(int priorityTypeId)
        {
            try
            {
                var priorityType = await _priorityTypeRepository.GetById(priorityTypeId);

                if (priorityType != null)
                {
                    return Ok(priorityType);
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
        public async Task<ActionResult> Update(int id, [FromBody] PriorityType priorityType)
        {
            try
            {
                var response = await _priorityTypeRepository.Update(id, priorityType);

                if (response > 0)
                {
                    return Ok(new { message = "Priority type updated!" });
                }
                else
                {
                    return NotFound(new { message = "Priority type not found!" });
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
                var response = await _priorityTypeRepository.Remove(id);
                if (response > 0)
                {
                    return Ok(new { message = "Priority deleted!" });
                }
                else
                {
                    return NotFound(new { message = "Priority not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
