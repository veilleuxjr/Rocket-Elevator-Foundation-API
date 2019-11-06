using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Rest.Models;

namespace Rocket_Rest.Controllers
{
    [Route("api/batteries")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly Rocket_RestContext _context;

        public BatteriesController(Rocket_RestContext context)
        {
            _context = context;
        }

        // GET: api/Battery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteryItems()
        {
            return await _context.batteries.ToListAsync();
        }

        // GET: api/Battery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> GetBattery(long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        // PUT: api/Battery/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery(long id, Battery battery)
        {
            if (id != battery.id)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
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

        // POST: api/Battery
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Battery>> PostBattery(Battery battery)
        {
            _context.batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.id }, battery);
        }

        // DELETE: api/Battery/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Battery>> DeleteBattery(long id)
        {
            var battery = await _context.batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return battery;
        }

        private bool BatteryExists(long id)
        {
            return _context.batteries.Any(e => e.id == id);
        }
    }
}
