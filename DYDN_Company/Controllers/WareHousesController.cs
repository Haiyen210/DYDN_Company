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
        public IEnumerable<WareHouse> GetWareHouses()
        {
            return _context.WareHouses;
        }

        // GET: api/WareHouses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWareHouse([FromRoute] int? id)
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

            return Ok(wareHouse);
        }

        // PUT: api/WareHouses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWareHouse([FromRoute] int? id, [FromBody] WareHouse wareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wareHouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(wareHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WareHouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            _context.WareHouses.Add(wareHouse);
            await _context.SaveChangesAsync();

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