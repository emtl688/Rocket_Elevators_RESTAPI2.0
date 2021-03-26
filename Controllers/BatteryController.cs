using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_RESTAPI2._0.Models;

namespace Rocket_Elevators_RESTAPI2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public BatteryController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Battery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Battery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> GetBattery(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        // PUT: api/Battery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery(long id, Battery battery)
        {
            if (id != battery.Id)
            {
                return BadRequest();
            }
            else if (battery.Status == "active" || battery.Status == "inactive" || battery.Status == "intervention")
            {
                _context.Entry(battery).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Content("Battery Id: " + battery.Id + " status has been changed to: " + battery.Status);
            }

            return Content("Please enter a valid status.");

        }

        // POST: api/Battery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Battery>> PostBattery(Battery battery)
        // {
        //     _context.Batteries.Add(battery);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        // }

        // // DELETE: api/Battery/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBattery(long id)
        // {
        //     var battery = await _context.Batteries.FindAsync(id);
        //     if (battery == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Batteries.Remove(battery);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool BatteryExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}
