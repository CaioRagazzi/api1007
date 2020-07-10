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
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                var response = await _categoryRepository.Create(category);

                if (response > 0)
                {
                    return CreatedAtRoute(nameof(GetCategoryById), new { categoryId = category.Id }, category);
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
                var categories = await _categoryRepository.GetAll();

                if (categories != null)
                {
                    return Ok(categories);
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

        [HttpGet("{categoryId}", Name = "GetCategoryById")]
        public async Task<ActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetById(categoryId);

                if (category != null)
                {
                    return Ok(category);
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
        public async Task<ActionResult> Update(int id, [FromBody] Category category)
        {
            try
            {
                var response = await _categoryRepository.Update(id, category);

                if (response > 0)
                {
                    return Ok(new { message = "Category updated!" });
                }
                else
                {
                    return NotFound(new { message = "Category not found!" });
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
                var response = await _categoryRepository.Remove(id);
                if (response > 0)
                {
                    return Ok(new { message = "Category deleted!" });
                }
                else
                {
                    return NotFound(new { message = "Category not found!" });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
