﻿using System;
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
    public class BillsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BillsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public IEnumerable<Bill> GetBills()
        {
            return _context.Bills;
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBill([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill([FromRoute] int? id, [FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.Id)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        [HttpPost]
        public async Task<IActionResult> PostBill([FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return Ok(bill);
        }

        private bool BillExists(int? id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}