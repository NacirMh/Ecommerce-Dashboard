using Ecommerce_Dashboard.Data.DTO;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IRepository<Comment> _Repository;

        public CommentsController(IRepository<Comment> repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _Repository.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var com = _Repository.GetById(id);

            if (com == null)
            {
                return NotFound($"Comment id {id} not found");
            }

            return com;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentDTO comDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("comment Object not valid");
            }
           Comment comment = new Comment()
            {
             Content = comDto.Content,
             CreatedAt = DateTime.Now,
             CustomerId = comDto.CustomerId,
             ProductId = comDto.ProductId
            };
            _Repository.Add(comment);
            return Ok(comment);
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = _Repository.GetById(id);

            if (comment == null)
            {
                return NotFound($"comment id {id} not found");
            }

            await _Repository.DeleteAsync(comment);

            return Ok();
        }
    }
}
