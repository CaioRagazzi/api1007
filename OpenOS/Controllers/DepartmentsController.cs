using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenOS.Data;
using OpenOS.Interfaces;
using OpenOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _departmentRepository.GetAll();
        }

        // GET: api/Departments/5
        [HttpGet("{departmentId}", Name = "GetDepartmentById")]
        public async Task<ActionResult<Department>> GetDepartmentById(int departmentId)
        {
            var department = await _departmentRepository.GetById(departmentId);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            try
            {
                var response = await _departmentRepository.Update(id, department);

                if (response > 0)
                {
                    return Ok(new { message = "Department updated!" });
                }
                else
                {
                    return NotFound(new { message = "Department not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            try
            {
                var response = await _departmentRepository.Create(department);

                if (response > 0)
                {
                    return CreatedAtRoute(nameof(GetDepartmentById), new { departmentId = department.Id }, department);
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

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            try
            {
                var response = await _departmentRepository.Remove(id);
                if (response > 0)
                {
                    return Ok(new { message = "Department deleted!" });
                }
                else
                {
                    return NotFound(new { message = "Department not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
