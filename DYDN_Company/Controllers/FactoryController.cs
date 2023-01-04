using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DYDN_Company.Models;

namespace DYDN_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        private readonly AppDBContext _context;

        public FactoryController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Factory
        [HttpGet]
        public IEnumerable<Factory> GetFactories()
        {
            return _context.Factories;
        }

        // GET: api/Factory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFactory([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return Ok(factory);
        }

        // PUT: api/Factory/5
        [HttpPost]
        [Route("PutFacrory")]
        public async Task<IActionResult> PutFactory( [FromBody] Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            factory.ModifiedDate = DateTime.Now;
            _context.Entry(factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Factory
        [HttpPost]
        public async Task<IActionResult> PostFactory([FromBody] Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            factory.CreatedDate = DateTime.Now;
            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.Id }, factory);
        }

        // DELETE: api/Factory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();

            return Ok(factory);
        }

        private bool FactoryExists(int? id)
        {
            return _context.Factories.Any(e => e.Id == id);
        }
    }
}