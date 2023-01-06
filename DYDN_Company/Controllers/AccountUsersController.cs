
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
    public class AccountUsersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AccountUsersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/AccountUsers
        [HttpGet]
        public IEnumerable<AccountUser> GetAccountUsers()
        {
            return _context.AccountUsers.Where(b => b.Status == true);
        }
        [HttpGet]
        [Route("TrashAccountUsers")]
        public IEnumerable<AccountUser> GetTrashAccountUsers()
        {
            return _context.AccountUsers.Where(b => b.Status == false);
        }
        // GET: api/AccountUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountUser([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountUser = await _context.AccountUsers.FindAsync(id);

            if (accountUser == null)
            {
                return NotFound();
            }

            return Ok(accountUser);
        }
        [HttpPost]
        [Route("RepeatAccountUsers")]
        public async Task<IActionResult> RepeatAccountUsers([FromBody] AccountUser accountUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(accountUser).State = EntityState.Modified;

            try
            {
                accountUser.Status = true;
                accountUser.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        [HttpPost]
        [Route("TemporaryDelete")]
        public async Task<IActionResult> TemporaryDelete([FromBody] AccountUser accountUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(accountUser).State = EntityState.Modified;

            try
            {
                accountUser.Status = false;
                //categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        // PUT: api/AccountUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountUser([FromRoute] int? id, [FromBody] AccountUser accountUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountUserExists(id))
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

        // POST: api/AccountUsers
        [HttpPost]
        public async Task<IActionResult> PostAccountUser([FromBody] AccountUser accountUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountUsers.Add(accountUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountUser", new { id = accountUser.Id }, accountUser);
        }

        // DELETE: api/AccountUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountUser([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountUser = await _context.AccountUsers.FindAsync(id);
            if (accountUser == null)
            {
                return NotFound();
            }

            _context.AccountUsers.Remove(accountUser);
            await _context.SaveChangesAsync();

            return Ok(accountUser);
        }

        private bool AccountUserExists(int? id)
        {
            return _context.AccountUsers.Any(e => e.Id == id);
        }
    }
}
