using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Football_API.Models;

namespace Football_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoutsController : ControllerBase
    {
        private readonly FootballDBContext _context;

        public ScoutsController(FootballDBContext context)
        {
            _context = context;
        }

        // GET: api/Scouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scouts>>> GetScouts()
        {
            return await _context.Scouts.ToListAsync();
        }

        // GET: api/Scouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scouts>> GetScouts(int id)
        {
            var scouts = await _context.Scouts.FindAsync(id);

            if (scouts == null)
            {
                return NotFound();
            }

            return scouts;
        }

        // PUT: api/Scouts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScouts(int id, Scouts scouts)
        {
            if (id != scouts.ScoutId)
            {
                return BadRequest();
            }

            _context.Entry(scouts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoutsExists(id))
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

        // POST: api/Scouts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Scouts>> PostScouts(Scouts scouts)
        {
            _context.Scouts.Add(scouts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScouts", new { id = scouts.ScoutId }, scouts);
        }

        // DELETE: api/Scouts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scouts>> DeleteScouts(int id)
        {
            var scouts = await _context.Scouts.FindAsync(id);
            if (scouts == null)
            {
                return NotFound();
            }

            _context.Scouts.Remove(scouts);
            await _context.SaveChangesAsync();

            return scouts;
        }

        private bool ScoutsExists(int id)
        {
            return _context.Scouts.Any(e => e.ScoutId == id);
        }
    }
}
