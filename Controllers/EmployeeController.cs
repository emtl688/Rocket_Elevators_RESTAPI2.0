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
    public class EmployeeController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public EmployeeController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //Validate user is a employee during registration
        // GET: api/Employee/Email/{federico@yost.biz}
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeEmail(string email)
        {

            IEnumerable<Employee> employeesAll = await _context.Employees.ToListAsync();

            foreach (Employee employee in employeesAll)
            {
                if (employee.Email == email)
                {
                    return employee;
                }
            }
            return NotFound();
        }
    }
}