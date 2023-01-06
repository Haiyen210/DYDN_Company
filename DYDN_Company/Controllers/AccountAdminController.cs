using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DYDN_Company.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginModel = DYDN_Company.Models.LoginModel;

namespace DYDN_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddCors")]
    public class AccountAdminController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AccountAdminController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            var account = _context.AccountAdmins.FirstOrDefault(x => x.Email == user.Email);
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            user.AccountName = account.Code;
            user.Role = account.Role;
            if (user.Email == account.Email && user.Password == account.Password && account.Status == true)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:54195/",
                    audience: "http://localhost:54195/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString, User = user });
            }
            return Unauthorized();
        }
       
        // GET: api/AccountAdmin
        [HttpGet]
        public IEnumerable<AccountAdminDisplay> GetAccountAdmins()
        {
          var data=  _context.AccountAdmins
        .Join(_context.Departments, ai => ai.DepartmentId,
              al => al.Id, (ai, al) => new
              {
                  Id = ai.Id,
                  Code = ai.Code,
                  Name = ai.Name,
                  Gender = ai.Gender,
                  Birthday = ai.Birthday,
                  Address = ai.Address,
                  Email = ai.Email,
                  Phone = ai.Phone,
                  Status = ai.Status,
                  Password = ai.Password,
                  Role = ai.Role,
                  DepartmentId = ai.DepartmentId,
                  CreatedDate = ai.CreatedDate,
                  ModifiedDate = ai.ModifiedDate,
                  DepartmentName = al.Name
              }).Select(x => new AccountAdminDisplay()
              {
                  Id = x.Id,
                  Code = x.Code,
                  Name = x.Name,
                  Gender = x.Gender,
                  Birthday = x.Birthday,
                  Address = x.Address,
                  Phone = x.Phone,
                  Status = x.Status,
                  Password = x.Password,
                  Role = x.Role,
                  Email = x.Email,
                  DepartmentId = x.DepartmentId,
                  CreatedDate = x.CreatedDate,
                  ModifiedDate = x.ModifiedDate,
                  DepartmentName = x.DepartmentName
              }).Where(x => x.Status == true).ToList();
            return data;
        }

        // GET: api/AccountAdmin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountAdmin([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountAdmin = await _context.AccountAdmins.FindAsync(id);
            if (accountAdmin == null)
            {
                return NotFound();
            }

            return Ok(accountAdmin);
        }

        // PUT: api/AccountAdmin/5
        [HttpPost]
        [Route("PutAccountAdmin")]
        public async Task<IActionResult> PutAccountAdmin([FromBody] AccountAdmin accountAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Entry(accountAdmin).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                accountAdmin = _context.AccountAdmins.Join(_context.Departments, ai => ai.DepartmentId,al => al.Id, (ai, al) => new
               {
                   Id = ai.Id,
                   Code = ai.Code,
                   Name = ai.Name,
                   Gender = ai.Gender,
                   Birthday = ai.Birthday,
                   Address = ai.Address,
                   Email = ai.Email,
                   Phone = ai.Phone,
                   Status = ai.Status,
                   Password = ai.Password,
                   Role = ai.Role,
                   DepartmentId = ai.DepartmentId,
                   CreatedDate = ai.CreatedDate,
                   ModifiedDate = ai.ModifiedDate,
                   DepartmentName = al.Name
               }).Where(x => x.Id == accountAdmin.Id).Select(x => new AccountAdminDisplay()
               {
                   Id = x.Id,
                   Code = x.Code,
                   Name = x.Name,
                   Gender = x.Gender,
                   Birthday = x.Birthday,
                   Address = x.Address,
                   Phone = x.Phone,
                   Status = x.Status,
                   Password = x.Password,
                   Role = x.Role,
                   Email = x.Email,
                   DepartmentId = x.DepartmentId,
                   CreatedDate = x.CreatedDate,
                   ModifiedDate = x.ModifiedDate,
                   DepartmentName = x.DepartmentName
               }).FirstOrDefault();
                
                return Ok(accountAdmin);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/AccountAdmin
        [HttpPost]
        public async Task<IActionResult> PostAccountAdmin([FromBody] AccountAdmin accountAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.AccountAdmins.Add(accountAdmin);
            await _context.SaveChangesAsync();
             accountAdmin = _context.AccountAdmins
           .Join(_context.Departments, ai => ai.DepartmentId,
                 al => al.Id, (ai, al) => new
                 {
                     Id = ai.Id,
                     Code = ai.Code,
                     Name = ai.Name,
                     Gender = ai.Gender,
                     Birthday = ai.Birthday,
                     Address = ai.Address,
                     Email = ai.Email,
                     Phone = ai.Phone,
                     Status = ai.Status,
                     Password = ai.Password,
                     Role = ai.Role,
                     DepartmentId = ai.DepartmentId,
                     CreatedDate = ai.CreatedDate,
                     ModifiedDate = ai.ModifiedDate,
                     DepartmentName = al.Name
                 }).Where(x => x.Id == accountAdmin.Id).Select(x => new AccountAdminDisplay()
                 {
                     Id = x.Id,
                     Code = x.Code,
                     Name = x.Name,
                     Gender = x.Gender,
                     Birthday = x.Birthday,
                     Address = x.Address,
                     Phone = x.Phone,
                     Status = x.Status,
                     Password = x.Password,
                     Role = x.Role,
                     Email = x.Email,
                     DepartmentId = x.DepartmentId,
                     CreatedDate = x.CreatedDate,
                     ModifiedDate = x.ModifiedDate,
                     DepartmentName = x.DepartmentName
                 }).FirstOrDefault();
            return CreatedAtAction("GetAccountAdmin", new { id = accountAdmin.Id }, accountAdmin);
        }
        [HttpGet]
        [Route("TrashAccountAdmin")]
        public IEnumerable<AccountAdmin> GetTrashAccountAdmin()
        {
            var data = _context.AccountAdmins
        .Join(_context.Departments, ai => ai.DepartmentId,
              al => al.Id, (ai, al) => new
              {
                  Id = ai.Id,
                  Code = ai.Code,
                  Name = ai.Name,
                  Gender = ai.Gender,
                  Birthday = ai.Birthday,
                  Address = ai.Address,
                  Email = ai.Email,
                  Phone = ai.Phone,
                  Status = ai.Status,
                  Password = ai.Password,
                  Role = ai.Role,
                  DepartmentId = ai.DepartmentId,
                  CreatedDate = ai.CreatedDate,
                  ModifiedDate = ai.ModifiedDate,
                  DepartmentName = al.Name
              }).Select(x => new AccountAdminDisplay()
              {
                  Id = x.Id,
                  Code = x.Code,
                  Name = x.Name,
                  Gender = x.Gender,
                  Birthday = x.Birthday,
                  Address = x.Address,
                  Phone = x.Phone,
                  Status = x.Status,
                  Password = x.Password,
                  Role = x.Role,
                  Email = x.Email,
                  DepartmentId = x.DepartmentId,
                  CreatedDate = x.CreatedDate,
                  ModifiedDate = x.ModifiedDate,
                  DepartmentName = x.DepartmentName
              }).Where(x => x.Status == false).ToList();
            return data;
        }
        [HttpPost]
        [Route("RepeatAccountAdmin")]
        public async Task<IActionResult> RepeatCategoryProduct([FromBody] AccountAdmin accountAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(accountAdmin).State = EntityState.Modified;

            try
            {
                accountAdmin.Status = true;
                accountAdmin.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        [HttpPost]
        [Route("TemporaryDelete")]
        public async Task<IActionResult> TemporaryDelete([FromBody] AccountAdmin accountAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(accountAdmin).State = EntityState.Modified;

            try
            {
                accountAdmin.Status = false;
                //categoryProduct.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
        // DELETE: api/AccountAdmin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountAdmin([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountAdmin = await _context.AccountAdmins.FindAsync(id);
            if (accountAdmin == null)
            {
                return NotFound();
            }

            _context.AccountAdmins.Remove(accountAdmin);
            await _context.SaveChangesAsync();

            return Ok(accountAdmin);
        }

        private bool AccountAdminExists(int? id)
        {
            return _context.AccountAdmins.Any(e => e.Id == id);
        }
    }
}