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
    public class CategoryProductController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CategoryProductController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProduct
        [HttpGet]
        public IEnumerable<CategoryProduct> GetCategoryProducts()
        {
            return _context.CategoryProducts.Where(b=> b.Status == true);
        }

        [HttpGet]
        [Route("TrashCategoryProduct")]
        public IEnumerable<CategoryProduct> GetTrashCategoryProducts()
        {
            return _context.CategoryProducts.Where(b => b.Status == false);
        }
        // GET: api/CategoryProduct/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryProduct([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryProduct = await _context.CategoryProducts.FindAsync(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return Ok(categoryProduct);
        }

        // PUT: api/CategoryProduct/5
        [HttpPost]
        [Route("PutCategoryProduct")]
        public async Task<IActionResult> PutCategoryProduct( [FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }
        [HttpPost]
        [Route("RepeatCategoryProduct")]
        public async Task<IActionResult> RepeatCategoryProduct([FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                categoryProduct.Status = true;
                categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        [HttpPost]
        [Route("TemporaryDelete")]
        public async Task<IActionResult> TemporaryDelete([FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                categoryProduct.Status = false;
                //categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        // POST: api/CategoryProduct
        [HttpPost]
        public async Task<IActionResult> PostCategoryProduct([FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoryProduct.CreatedDate = DateTime.Now;
            _context.CategoryProducts.Add(categoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.Id }, categoryProduct);
        }

        // DELETE: api/CategoryProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryProduct([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryProduct = await _context.CategoryProducts.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProducts.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return Ok(categoryProduct);
        }
        
        private bool CategoryProductExists(int? id)
        {
            return _context.CategoryProducts.Any(e => e.Id == id);
        }
    }
}