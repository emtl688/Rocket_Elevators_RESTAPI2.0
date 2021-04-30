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
    public class ElevatorController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public ElevatorController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // Retrieves a list of all Elevators in our database
        // GET https://localhost:5001/api/elevator
        [HttpGet]
        public ActionResult<List<Elevator>> GetAll()
        {
            return _context.Elevators.ToList();
        }


        // Retrieves a list of all Elevators in our database requiring maintenance ("Intervention" + "Inactive")
        //  GET https://localhost:5001/api/elevator/non-operational
        [HttpGet("non-operational")]
        public IEnumerable<Elevator> GetElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.Status != "Active"
                                             select list_elev;

            return Elevators.ToList();
        }



        // Retrieves a list of all Active Elevators in our database
        // GET https://localhost:5001/api/elevator/active
        [HttpGet("active")]
        public IEnumerable<Elevator> GetActiveElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.Status == "Active"
                                             select list_elev;

            return Elevators.ToList();
        }


        // Retrieves all information about a specific Elevator (using its ID)
        // GET https://localhost:5001/api/elevator/[ID]
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }

        // Modifies status of an existing Elevator in our database
        // PUT https://localhost:5001/api/elevator/[ID]/Status
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmodifyElevatorStatus(long id, string status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            var elevator = await _context.Elevators.FindAsync(id);

            elevator.Status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
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

        // Creates a new Elevator in our database
        [HttpPost]
        public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        {
            _context.Elevators.Add(elevator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevator", new { id = elevator.Id }, elevator);
        }

        // Deletes an Elevator from our database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElevator(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);
            if (elevator == null)
            {
                return NotFound();
            }

            _context.Elevators.Remove(elevator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElevatorExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
