using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _Repository;

        public CategoryController(IRepository<Category> repository)
        {
            _Repository = repository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _Repository.GetAllAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var cat = await  _Repository.GetByIdAsync(id);

            if (cat == null)
            {
                return NotFound($"Cat id {id} not found");
            }

            return cat;
        }

        
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("cat Object not valid");
            }


            _Repository.Add(cat);
            return Ok(cat);
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("tag Object not valid");
            }

            var category = _Repository.GetById(id);

            if (category != null)
            {
                category.Name = cat.Name;
                category.Description = cat.Description;
                category.Image = cat.Image;
                await _Repository.UpdateAsync(category);
                return (Ok());
            }

            return NotFound($"cat Id {category.Id} not found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cat = _Repository.GetById(id);

            if (cat == null)
            {
                return NotFound($"cat id {id} not found");
            }

            await _Repository.DeleteAsync(cat);

            return Ok();
        }
    }
}
