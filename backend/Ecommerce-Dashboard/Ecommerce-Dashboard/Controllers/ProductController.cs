using Ecommerce_Dashboard.Data.DTO;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _Repository;

        public ProductController(IRepository<Product> repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _Repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("product Object not valid");
            }
            Product product = new Product()
            {
                tagId = productDTO.tagId,
                CategoryId = productDTO.CategoryId,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Discount = productDTO.Discount,
                Featured = productDTO.Featured,
                FirstDate = productDTO.FirstDate,
                Quantity = productDTO.Quantity,
                Price = productDTO.Price,
                Image = productDTO.Image,
            };
            _Repository.Add(product);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _Repository.GetById(id);

            if (product == null)
            {
                return NotFound($"product id {id} not found");
            }

            return product;
        }

      

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("product Object not valid");
            }

            var product = _Repository.GetById(id);

            if (product != null)
            {
                product.CategoryId = productDTO.CategoryId;
                product.tagId = productDTO.tagId;
                product.Name = productDTO.Name;
                product.UpdateDate = productDTO.UpdateDate;
                product.Description = productDTO.Description;
                product.Discount = productDTO.Discount;
                product.Featured = productDTO.Featured;
                product.FirstDate = productDTO.FirstDate;
                product.Quantity = productDTO.Quantity;
                product.Price = productDTO.Price;
                product.Image = productDTO.Image;
                await _Repository.UpdateAsync(product);
                return (Ok());
            }

            return NotFound($"cat Id {id} not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = _Repository.GetById(id);

            if (product == null)
            {
                return NotFound($"product id {id} not found");
            }

            await _Repository.DeleteAsync(product);

            return Ok();
        }

       

    }
}
