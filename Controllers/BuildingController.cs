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
    public class BuildingController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public BuildingController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Building
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        // GET: api/Building/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(long id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }
        //GET: api/Building/Intervention
        [HttpGet ("Intervention")]
        public ActionResult<IEnumerable<Building>> GetIntervention()
        {
            var AllBatteries = _context.Batteries.ToList();
            var AllBuildings = _context.Buildings.ToList();
            var AllColumns = _context.Columns.ToList();
            var AllElevators = _context.Elevators.ToList();
            List<Column> interventionColumn = new List<Column>();
            List<Elevator> interventionElevator = new List<Elevator>();
            List<Battery> interventionBattery = new List<Battery>();
            List<Building> buildingsIntervention = new List<Building>();

            
            foreach (Elevator elevator in AllElevators) // Check if any elevator status = intervention
            {
                if (elevator.Status == "Intervention")
                {
                    Int64 counter = 0;
                    foreach (Elevator E in interventionElevator)
                    {
                        if (E.Id == elevator.ColumnId)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        interventionElevator.Add(elevator);
                        Console.WriteLine(interventionElevator);
                    }
                }
            }

            foreach (Elevator ele in interventionElevator) // Add the elevator's column in intervention column
            {
                foreach (Column col in AllColumns)
                {
                    if (col.Id == ele.ColumnId)
                    {
                        interventionColumn.Add(col);
                        Console.WriteLine(interventionColumn);
                    }
                }
            }

            foreach (Column column in AllColumns) // Check if any column status = intervention
            {
                if (column.Status == "Intervention")
                {
                    Int64 counter = 0;
                    foreach (Column C in interventionColumn)
                    {
                        if (C.Id == column.BatteryId)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        interventionColumn.Add(column);
                        Console.WriteLine(interventionColumn);
                    }
                }
            }

            foreach (Column columns in interventionColumn) // Add the column's battery in intervention battery
            {
                foreach (Battery bat in AllBatteries)
                {
                    if (bat.Id == columns.BatteryId)
                    {
                        interventionBattery.Add(bat);
                        Console.WriteLine(interventionBattery);
                    }
                }
            }

            foreach (Battery battery in AllBatteries) // Check if any battery status = intervention
            {
                if (battery.Status == "Intervention")
                {
                    Int64 counter = 0;
                    foreach (Battery BA in interventionBattery)
                    {
                        if (BA.Id == battery.BuildingId)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        interventionBattery.Add(battery);
                        Console.WriteLine(interventionBattery);
                    }
                }
            }

            foreach (Battery batteries in interventionBattery) // Add the Battery's Building in intervention battery
            {
                foreach (Building building in AllBuildings)
                {
                    if (building.Id == batteries.BuildingId)
                    // Console.WriteLine(building.Id);
                    // Console.WriteLine(batteries.BuildingId);
                    {
                        buildingsIntervention.Add(building);
                        Console.WriteLine(buildingsIntervention);
                    }
                }
            }
            buildingsIntervention = buildingsIntervention.OrderBy(o=>o.Id).ToList();
            List<Building> buildingsInterventionNoDup = buildingsIntervention.Distinct().ToList();
            return buildingsInterventionNoDup;
        }

        // PUT: api/Building/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBuilding(long id, Building building)
        // {
        //     if (id != building.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(building).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BuildingExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Building
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Building>> PostBuilding(Building building)
        // {
        //     _context.Buildings.Add(building);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        // }

        // // DELETE: api/Building/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBuilding(long id)
        // {
        //     var building = await _context.Buildings.FindAsync(id);
        //     if (building == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Buildings.Remove(building);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool BuildingExists(long id)
        // {
        //     return _context.Buildings.Any(e => e.Id == id);
        // }
    }
}
