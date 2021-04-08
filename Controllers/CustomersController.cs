using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_RESTAPI2._0.Models;

namespace Rocket_Elevators_RESTAPI2._0.Controllers
{

    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public CustomersController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        // GET: api/Customers/example@client.com
        [HttpGet("{email}")]
        public async Task<ActionResult<Customer>> GetCustomer(string email)
        {
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.EmailOfCompanyContact == email)
                                                .FirstOrDefaultAsync();

            // customer = await _context.customers.Include("Buildings.Addresses")
            //                                     .Where(c => c.cpy_contact_email == email)
            //                                     .FirstOrDefaultAsync();          

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // ========== Verify email for register at the Customer's Portal =========================================================================
        // GET: api/Customers/verify/example@client.com
        [HttpGet("verify/{email}")]
        public async Task<ActionResult> VerifyEmail(string email)
        {
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.EmailOfCompanyContact == email)
                                                .FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // ========== Put for update the customer infos =========================================================================
        // PUT: api/Customers/example@client.com
        [HttpPut]
        public async Task<ActionResult<Customer>> PutCustomer(Customer customer)
        {
            var customerToUpdate = await _context.Customers
                                                .Where(c => c.EmailOfCompanyContact == customer.EmailOfCompanyContact)
                                                .FirstOrDefaultAsync();

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.FullNameOfCompanyContact = customer.FullNameOfCompanyContact;
            customerToUpdate.CompanyContactPhone = customer.CompanyContactPhone;
            customerToUpdate.FullNameOfServiceTechnicalAuthority = customer.FullNameOfServiceTechnicalAuthority;
            customerToUpdate.TechnicalAuthorityPhoneForService = customer.TechnicalAuthorityPhoneForService;
            customerToUpdate.TechnicalManagerEmailForService = customer.TechnicalManagerEmailForService;
            customerToUpdate.CompanyDescription = customer.CompanyDescription;

            await _context.SaveChangesAsync();

            return customerToUpdate;
        }
    }
}