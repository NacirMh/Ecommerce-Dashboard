using Ecommerce_Dashboard.Data;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IRepository<Billboard> _Repository;
        public BillboardController(IRepository<Billboard> repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billboard>>> GetBillboards()
        {
            return await _Repository.GetAllAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Billboard>> GetBillboard(int id)
        {
            var billboard = await _Repository.GetByIdAsync(id);

            if (billboard == null)
            {
                return NotFound();
            }

            return billboard;
        }

        [HttpPost]
        public async Task<ActionResult<Billboard>> PostBillboard(Billboard billboard)
        {
            await _Repository.AddAsync(billboard);
            return CreatedAtAction(nameof(GetBillboard), new { id = billboard.Id }, billboard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBillBoard(int id,Billboard bill)
        {
            var billboard = await _Repository.GetByIdAsync(id);

            if (billboard != null)
            {
                await _Repository.UpdateAsync(bill);
                return (Ok());
            }

            return NotFound($"bill Id {bill.Id} not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillboard(int id)
        {
            var billboard = _Repository.GetById(id);
            if (billboard == null)
            {
                return NotFound($"bill Id {id} not found");
            }

            await _Repository.DeleteAsync(billboard);

            return Ok();
        }

        
    }
}
