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
    public class HeadStaffsController : ControllerBase
    {
        private readonly FootballDBContext _context;

        public HeadStaffsController(FootballDBContext context)
        {
            _context = context;
        }

        // GET: api/HeadStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeadStaffs>>> GetHeadStaffs()
        {
            return await _context.HeadStaffs.ToListAsync();
        }

        // GET: api/HeadStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeadStaffs>> GetHeadStaffs(int id)
        {
            var headStaffs = await _context.HeadStaffs.FindAsync(id);

            if (headStaffs == null)
            {
                return NotFound();
            }

            return headStaffs;
        }

        // PUT: api/HeadStaffs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeadStaffs(int id, HeadStaffs headStaffs)
        {
            if (id != headStaffs.HeadStaffId)
            {
                return BadRequest();
            }

            _context.Entry(headStaffs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadStaffsExists(id))
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

        // POST: api/HeadStaffs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HeadStaffs>> PostHeadStaffs(HeadStaffs headStaffs)
        {
            _context.HeadStaffs.Add(headStaffs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeadStaffs", new { id = headStaffs.HeadStaffId }, headStaffs);
        }

        // DELETE: api/HeadStaffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HeadStaffs>> DeleteHeadStaffs(int id)
        {
            var headStaffs = await _context.HeadStaffs.FindAsync(id);
            if (headStaffs == null)
            {
                return NotFound();
            }

            _context.HeadStaffs.Remove(headStaffs);
            await _context.SaveChangesAsync();

            return headStaffs;
        }

        private bool HeadStaffsExists(int id)
        {
            return _context.HeadStaffs.Any(e => e.HeadStaffId == id);
        }
    }
}
