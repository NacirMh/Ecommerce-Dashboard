using Castle.Core.Resource;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _Repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _Repository = repository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _Repository.GetAllAsync();
        }

   
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var cat = _Repository.GetById(id);

            if (cat == null)
            {
                return NotFound($"Customer id {id} not found");
            }

            return cat;
        }

        
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("customer Object not valid");
            }

            _Repository.Add(customer);
            return Ok(customer);
        }

        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer cat)
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
        }*/


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var cat = _Repository.GetById(id);

            if (cat == null)
            {
                return NotFound($"customer id {id} not found");
            }

            await _Repository.DeleteAsync(cat);

            return Ok();
        }
    }

}

