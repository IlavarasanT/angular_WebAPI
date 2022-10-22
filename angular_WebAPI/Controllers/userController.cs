using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using angular_WebAPI.Data;
using angular_WebAPI.Model;

namespace angular_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public userController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user_table>>> Getuser_table()
        {
            return await _context.user_table.ToListAsync();
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user_table>> Getuser_table(Guid id)
        {
            var user_table = await _context.user_table.FindAsync(id);

            if (user_table == null)
            {
                return NotFound();
            }

            return user_table;
        }

        // PUT: api/user/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser_table(Guid id, user_table user_table)
        {
            if (id != user_table.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user_table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_tableExists(id))
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

        // POST: api/user
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user_table>> Postuser_table(user_table user_table)
        {
            _context.user_table.Add(user_table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuser_table", new { id = user_table.UserId }, user_table);
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser_table(Guid id)
        {
            var user_table = await _context.user_table.FindAsync(id);
            if (user_table == null)
            {
                return NotFound();
            }

            _context.user_table.Remove(user_table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool user_tableExists(Guid id)
        {
            return _context.user_table.Any(e => e.UserId == id);
        }
    }
}
