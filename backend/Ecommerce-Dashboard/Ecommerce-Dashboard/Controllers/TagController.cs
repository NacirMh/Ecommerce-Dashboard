using Ecommerce_Dashboard.Data;
using Ecommerce_Dashboard.Data.DTO;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IRepository<Tag> _Repository;

        public TagController(IRepository<Tag> repository)
        {
            _Repository = repository;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await _Repository.GetAllAsync();
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task <ActionResult<Tag>> GetTag(int id)
        { 
            var tag = _Repository.GetById(id);

            if (tag == null)
            {
                return NotFound($"Tag id {id} not found");
            }
      
            return tag;
        }

        // POST: api/Tag
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("tag Object not valid");
            }


            _Repository.Add(tag);
            return Ok(tag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tagdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("tag Object not valid");
            }

            var tag = _Repository.GetById(id);

            if (tag != null)
            {
                tag.Name = tagdto.Name;
                tag.Description = tagdto.Description;
                await _Repository.UpdateAsync(tag);
                return (Ok());
            }

            return NotFound($"tag Id {tag.Id} not found");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = _Repository.GetById(id);

            if (tag == null)
            {
                return NotFound($"tag id {id} not found");
            }

            await _Repository.DeleteAsync(tag);

            return Ok();
        }

    
    }
}
