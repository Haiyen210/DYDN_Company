using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DYDN_Company.Models;
using Microsoft.AspNetCore.Cors;
using System.Data.SqlClient;

namespace DYDN_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddCors")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OrderDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = _context.OrderDetails
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
                }).Where(x => x.OrderId == id).ToList();

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

      

        // PUT: api/OrderDetails/5
        [HttpPost]
        [Route("PutProductQuantity")]
        public async Task<IActionResult> PutProductQuantity([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var orderDetails = _context.OrderDetails.Include(x => x.Product).Where(x => x.ProductId == orderDetail.ProductId).FirstOrDefault();
            var product = _context.Products.Where(x => x.Id == orderDetail.ProductId).FirstOrDefault();
            product.Quantity = product.Quantity - orderDetail.Quantity;
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
            }

            return NoContent();
        }

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<IActionResult> PostOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            orderDetail.CreatedDate = DateTime.Now;
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail =  _context.OrderDetails.Where(x => x.OrderId == id).ToList();
            if (orderDetail == null)
            {
                return NotFound();
            }
            for (int i = 0; i < orderDetail.Count; i++)
            {
                _context.OrderDetails.Remove(orderDetail[i]);
                await _context.SaveChangesAsync();
            }
           
           

            return Ok(orderDetail);
        }

        private bool OrderDetailExists(int? id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}