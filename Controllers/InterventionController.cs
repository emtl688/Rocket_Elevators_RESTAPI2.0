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
    public class InterventionController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public InterventionController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Intervention
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Intervention/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }


        //GET: Returns all fields of all intervention Request records that do not have a start date and are in "Pending" status.
        // GET https://localhost:5001/api/intervention/pending
        [HttpGet("pending")]
        public IEnumerable<Intervention> GetPendingInterventions()
        {
            IQueryable<Intervention> Interventions =
            from list_ints in _context.Interventions
            where list_ints.StartDate == null && list_ints.Status == "Pending"
            select list_ints;

            return Interventions.ToList();
        }

        // PUT: Change the status of the intervention request to "InProgress" and add a start date and time (Timestamp).
        // PUT: Change the status of the request for action to "Completed" and add an end date and time (Timestamp).
        // https://localhost:5001/api/intervention/{id}/{status}
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Intervention>> PutInProgress(long id, string status)
        {

            if (status == "InProgress")
            {
                var intervention = await _context.Interventions.FindAsync(id);
                intervention.StartDate = System.DateTime.Now;
                intervention.Status = status;
                await _context.SaveChangesAsync();
                return intervention;
            }
            else if (status == "Completed")
            {
                var intervention = await _context.Interventions.FindAsync(id);
                intervention.Status = status;
                intervention.EndDate = System.DateTime.Now;
                await _context.SaveChangesAsync();
                return intervention;
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Intervention>> PostIntervention(Intervention newIntervention)
        {
            newIntervention.StartDate = DateTime.Now;
            newIntervention.Status = "InProgress";
            newIntervention.Result = "Incomplete";
            newIntervention.EmployeeId = null;

            _context.Interventions.Add(newIntervention);
            await _context.SaveChangesAsync();

            return newIntervention;
        }

        // DELETE: api/Intervention/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(intervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterventionExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
