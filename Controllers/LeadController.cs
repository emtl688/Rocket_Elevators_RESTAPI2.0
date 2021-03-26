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
    public class LeadController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public LeadController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Lead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/Lead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(long id)
        {
            var lead = await _context.Leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        // PUT: api/Lead/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(long id, Lead lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Lead
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Lead>> PostLead(Lead lead)
        // {
        //     _context.Leads.Add(lead);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        // }

        // // DELETE: api/Lead/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteLead(long id)
        // {
        //     var lead = await _context.Leads.FindAsync(id);
        //     if (lead == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Leads.Remove(lead);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool LeadExists(long id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
