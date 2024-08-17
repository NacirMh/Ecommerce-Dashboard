using Ecommerce_Dashboard.Data.DTO;
using Ecommerce_Dashboard.Data.Models;
using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _Repository;

        public OrderController(IRepository<Order> repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _Repository.GetAllAsync();
        }

        /*[HttpGet]
         public async Task<ActionResult<ICollection<OrderDTO>>> GetOrders()
         {
             var orders = await _Repository.GetAllAsync();

             if (orders != null)
             {
                 ICollection<OrderDTO> result = new List<OrderDTO>();
                 foreach (var order in orders.Value)
                 {
                     OrderDTO dto = new OrderDTO()
                     {
                         City = order.City,
                         Country = order.Country,
                         CustomerId = order.CustomerId,
                         EmailTo = order.EmailTo,
                         FullName = order.FullName,
                         Status = order.Status,
                         TotalAmount = order.TotalAmount,
                         ZipCode = order.ZipCode
                     };
                     if (order.OrderProducts.Any())
                     {
                         foreach(var product in order.OrderProducts)
                         {
                             ProductOrderDTO productOrderDTO = new ProductOrderDTO()
                             {
                                 ProductId = product.ProductId,
                                 Product = product.Product,
                                 AllQuantity = product.Quantity,
                                 Quantity = product.Quantity,
                             };
                             dto.Products.Add(productOrderDTO);
                         }
                     }
                     result.Add(dto);
                 }
                 return Ok(result);

             }
             return NotFound();
         }
         */

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _Repository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        [HttpPost]
        public async Task<ActionResult> PostOrder(OrderDTO orderdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("oder object not valid");
            };

            Order order = new Order()
            {
                CustomerId = orderdto.CustomerId,
                City = orderdto.City,
                Country = orderdto.Country,
                EmailTo = orderdto.EmailTo,
                FullName = orderdto.FullName,
                Status = orderdto.Status,
                ZipCode = orderdto.ZipCode,
                TotalAmount = orderdto.TotalAmount
            };
            if (orderdto.Products.Any())
            {
                foreach (var product in orderdto.Products)
                {
                    OrderProduct productorder = new OrderProduct()
                    {
                        ProductId = product.ProductId,
                        AllQuantity = product.Quantity,
                        Quantity = product.Quantity,
                    };
                    order.OrderProducts.Add(productorder);
                }
            }
            _Repository.Add(order);
            return Ok(order);
        }
        [HttpPut("updateStatus/{id}")]
        public async Task<ActionResult> PutOrder(int id, [FromBody] bool newStatus)
        {
            var order = _Repository.GetById(id);
            if (order == null)
            {
                return NotFound($"order id {id} not found ");
            }
            order.Status = newStatus;
            _Repository.Update(order);
            return Ok(order);
         }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder(int id, OrderDTO orderdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("oder object not valid");
            };
            var order = _Repository.GetById(id);
            if(order == null)
            {
                return NotFound($"order id {id} not found ");
            }
            order.CustomerId = orderdto.CustomerId;
            order.City = orderdto.City;
            order.Country = orderdto.Country;
            order.EmailTo = orderdto.EmailTo;
            order.FullName = orderdto.FullName;
            order.Status = orderdto.Status;
            order.ZipCode = orderdto.ZipCode;
            order.TotalAmount = orderdto.TotalAmount;

            if (orderdto.Products.Any())
            {
                foreach (var product in orderdto.Products)
                {
                    OrderProduct productorder = new OrderProduct()
                    {
                        ProductId = product.ProductId,
                        AllQuantity = product.Quantity,
                        Quantity = product.Quantity,
                    };
                    order.OrderProducts.Add(productorder);
                }
            }
            _Repository.Update(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = _Repository.GetById(id);

            if (order == null)
            {
                return NotFound($"Order id {id} not found");
            }

            await _Repository.DeleteAsync(order);

            return Ok();
        }


    }
}
