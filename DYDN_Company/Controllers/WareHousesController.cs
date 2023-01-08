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
    public class WareHousesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public WareHousesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/WareHouses
        [HttpGet]
        public IEnumerable<WareHouseDisplayFactory> GetWareHouses()
        {
            var warehouses = _context.WareHouses
            .Join(_context.Factories, ai => ai.FactoryID,
                  al => al.Id, (ai, al) => new
                  {
                      Id = ai.Id,
                      Code = ai.Code,
                      Name = ai.Name,
                      FactoryID = ai.FactoryID,
                      Status = ai.Status,
                      CreatedDate = ai.CreatedDate,
                      ModifiedDate = ai.ModifiedDate,
                      FactoryName = al.Name
                  }).Select(x => new WareHouseDisplayFactory()
                  {
                      Id = x.Id,
                      Code = x.Code,
                      Name = x.Name,
                      FactoryID = x.FactoryID,
                      Status = x.Status,
                      CreatedDate = x.CreatedDate,
                      ModifiedDate = x.ModifiedDate,
                      FactoryName = x.FactoryName
                  }).Where(x => x.Status == 1).ToList();
            return warehouses;
        }

        // GET: api/WareHouses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWareHouse([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var wareHouse = await _context.WareHouses.FindAsync(id);

            var data = _context.WareHouses
        .Join(_context.Products, ai => ai.Id,
              al => al.WareHouseID, (ai, al) => new
              {
                  Id = ai.Id,
                  Code = ai.Code,
                  Name = ai.Name,
                  ProductCode = al.Code,
                  ProductName = al.Name,
                  ProductPrice = al.Price,
                  ProductSalePrice = al.SalePrice,
                  ProductQuantity = al.Quantity,
                  ProductImages = al.Images,
                  ProductStatus = al.Status

              }).Where(x => x.Id == id).Select(x => new WareHouseDisplay
              {
                  Id = x.Id,
                  Code = x.Code,
                  Name = x.Name,
                  ProductCode = x.Code,
                  ProductName = x.Name,
                  ProductPrice = x.ProductPrice,
                  ProductSalePrice = x.ProductSalePrice,
                  ProductQuantity = x.ProductQuantity,
                  ProductImages = x.ProductImages,
                  ProductStatus = x.ProductStatus

              }).Where(x => x.ProductStatus == true).ToList();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/WareHouses/5
        [HttpPost]
        [Route("Putwarehouse")]
        public async Task<IActionResult> PutWareHouse([FromBody] WareHouse wareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(wareHouse).State = EntityState.Modified;

            try
            {
                wareHouse.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                wareHouse = _context.WareHouses
            .Join(_context.Factories, ai => ai.FactoryID,
                  al => al.Id, (ai, al) => new
                  {
                      Id = ai.Id,
                      Code = ai.Code,
                      Name = ai.Name,
                      FactoryID = ai.FactoryID,
                      Status = ai.Status,
                      CreatedDate = ai.CreatedDate,
                      ModifiedDate = ai.ModifiedDate,
                      FactoryName = al.Name
                  }).Where(x => x.Id == wareHouse.Id).Select(x => new WareHouseDisplayFactory()
                  {
                      Id = x.Id,
                      Code = x.Code,
                      Name = x.Name,
                      FactoryID = x.FactoryID,
                      Status = x.Status,
                      CreatedDate = x.CreatedDate,
                      ModifiedDate = x.ModifiedDate,
                      FactoryName = x.FactoryName
                  }).FirstOrDefault();
                return Ok(wareHouse);
            }
            catch (DbUpdateConcurrencyException)
            {
              
            }

            return NoContent();
        }

        // POST: api/WareHouses
        [HttpPost]
        public async Task<IActionResult> PostWareHouse([FromBody] WareHouse wareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            wareHouse.CreatedDate = DateTime.Now;
            _context.WareHouses.Add(wareHouse);
            await _context.SaveChangesAsync();
            wareHouse = _context.WareHouses
         .Join(_context.Factories, ai => ai.FactoryID,
               al => al.Id, (ai, al) => new
               {
                   Id = ai.Id,
                   Code = ai.Code,
                   Name = ai.Name,
                   FactoryID = ai.FactoryID,
                   Status = ai.Status,
                   CreatedDate = ai.CreatedDate,
                   ModifiedDate = ai.ModifiedDate,
                   FactoryName = al.Name
               }).Where(x => x.Id == wareHouse.Id).Select(x => new WareHouseDisplayFactory()
               {
                   Id = x.Id,
                   Code = x.Code,
                   Name = x.Name,
                   FactoryID = x.FactoryID,
                   Status = x.Status,
                   CreatedDate = x.CreatedDate,
                   ModifiedDate = x.ModifiedDate,
                   FactoryName = x.FactoryName
               }).FirstOrDefault();
            return CreatedAtAction("GetWareHouse", new { id = wareHouse.Id }, wareHouse);
        }

        // DELETE: api/WareHouses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWareHouse([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wareHouse = await _context.WareHouses.FindAsync(id);
            if (wareHouse == null)
            {
                return NotFound();
            }

            _context.WareHouses.Remove(wareHouse);
            await _context.SaveChangesAsync();

            return Ok(wareHouse);
        }

        private bool WareHouseExists(int? id)
        {
            return _context.WareHouses.Any(e => e.Id == id);
        }
    }
}