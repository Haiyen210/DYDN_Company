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
    public class ProductController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<ProductDisplay> GetProducts()
        {
            var data = _context.Products
        .Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).Where(x => x.Status == true).ToList();
            return data;
        }

        [HttpGet]
        [Route("TrashProduct")]
        public IEnumerable<Product> GetTrashProduct()
        {
            var data = _context.Products
        .Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).Where(x => x.Status == false).ToList();
            return data;
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _context.Products.Include(c => c.Category).Include(w => w.WareHouse).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            else
            {
                var productModel = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    CategoryId = product.CategoryId,
                    WareHouseID = product.WareHouseID,
                    CategoryName = product.Category.Name,
                    WarehouseName = product.WareHouse.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Images = product.Images,
                    SalePrice = product.SalePrice,
                    Status = product.Status,
                    CreatedDate = product.CreatedDate,
                    ModifiedDate = product.ModifiedDate
                };
                return Ok(productModel);
            }
        }

        // PUT: api/Products/5
        [HttpPost]
        [Route("PutProduct")]
        public async Task<IActionResult> PutProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Entry(product).State = EntityState.Modified;

            try
            {
                product.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                product = _context.Products.Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Where(x=> x.wa.ai.Id == product.Id).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).FirstOrDefault();
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        [HttpPost]
        [Route("RepeatProduct")]
        public async Task<IActionResult> RepeatProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                product.Status = true;
                await _context.SaveChangesAsync();

                product = _context.Products.Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Where(x => x.wa.ai.Id == product.Id).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).FirstOrDefault();
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        [HttpPost]
        [Route("TemporaryDelete")]
        public async Task<IActionResult> TemporaryDelete([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                product.Status = false;
                //categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();


                product = _context.Products.Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Where(x => x.wa.ai.Id == product.Id).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).FirstOrDefault();
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.CreatedDate = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            product = _context.Products.Join(_context.CategoryProducts, ai => ai.CategoryId,
              al => al.Id, (ai, al) => new { ai, al }).Join(_context.WareHouses, wa => wa.ai.WareHouseID,
              qu => qu.Id, (wa, qu) => new { wa, qu }).Where(x => x.wa.ai.Id == product.Id).Select(x => new ProductDisplay
              {
                  Id = x.wa.ai.Id,
                  Code = x.wa.ai.Code,
                  Name = x.wa.ai.Name,
                  Description = x.wa.ai.Description,
                  Price = x.wa.ai.Price,
                  SalePrice = x.wa.ai.SalePrice,
                  Quantity = x.wa.ai.Quantity,
                  Images = x.wa.ai.Images,
                  CategoryId = x.wa.ai.CategoryId,
                  WareHouseID = x.wa.ai.WareHouseID,
                  Status = x.wa.ai.Status,
                  CreatedDate = x.wa.ai.CreatedDate,
                  ModifiedDate = x.wa.ai.ModifiedDate,
                  WarehouseName = x.qu.Name,
                  CategoryName = x.wa.al.Name
              }).FirstOrDefault();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        private bool ProductExists(int? id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}