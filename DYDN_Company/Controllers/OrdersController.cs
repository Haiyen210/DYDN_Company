using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DYDN_Company.Models;
using Microsoft.AspNetCore.Cors;

namespace DYDN_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddCors")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OrdersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.Id);
        }
        [HttpGet]
        [Route("orderReturn")]
        public IEnumerable<Order> GetOrdersReturn()
        {
            return _context.Orders.OrderByDescending(x => x.Id).Where(x => x.Status == 6);
        }
        [HttpGet]
        [Route("orderSuccess")]
        public IEnumerable<Order> GetOrdersSuccess()
        {
            return _context.Orders.OrderByDescending(x => x.Id).Where(x => x.Status == 3);
        }
        [HttpGet]
        [Route("OrderHistory/{name}")]
        public async Task<IActionResult> GetOrdersSuccess(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order =  _context.Orders.Where(x => x.Status == 3 && x.Name.Equals(name)).ToList();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpGet]
        [Route("GetAllOrders/{name}")]
        public IEnumerable<Order> GetOrders(string name)
        {
            var order = _context.Orders.Where(x=>x.Name.Equals(name)).ToList();
            return order;
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/
        [HttpPost]
        [Route("PutOrder")]
        public async Task<IActionResult> PutOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

         
            order.ModifiedDate = DateTime.Now;
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(order);
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.CreatedDate = DateTime.Now;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPost]
        [Route("ProductQuantity")]
        public async Task<IActionResult> ProductQuantity([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderDetails = _context.OrderDetails
         .Join(_context.Products, od => od.ProductId,
               p => p.Id, (od, p) => new
               {
                   Id = od.Id,
                   ProductId = od.ProductId,
                   Quantity = od.Quantity,
                   Price = od.Price,
                   Status = od.Status,
                   OrderId = od.OrderId,
                   CreatedDate = od.CreatedDate,
                   ModifiedDate = od.ModifiedDate,
                   ProductCode = p.Code,
                   ProductName = p.Name
               }).Select(x => new DisplayOrderDetail()
               {
                   Id = x.Id,
                   ProductId = x.ProductId,
                   Quantity = x.Quantity,
                   Price = x.Price,
                   Status = x.Status,
                   OrderId = x.OrderId,
                   CreatedDate = x.CreatedDate,
                   ModifiedDate = x.ModifiedDate,
                   ProductCode = x.ProductCode,
                   ProductName = x.ProductName
               }).Where(x => x.OrderId == order.Id).ToList();
            for (int i = 0; i < orderDetails.Count(); i++)
            {
                var product = _context.Products.Where(x => x.Id == orderDetails[i].ProductId).FirstOrDefault();
                product.Quantity = product.Quantity + orderDetails[i].Quantity;
                _context.Entry(product).State = EntityState.Modified;
            }
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }
        private bool OrderExists(int? id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}