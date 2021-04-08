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
    public class CustomerController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public CustomerController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // Get all the assets belonging to a customer using their ID
        // GET: api/Customer/example@email.com
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

        // Verify email exists in DB for customer registration in Portal
        // GET: api/Customer/verify/example@email.com
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

        // To update customer info via Customer Portal
        // PUT: api/Customer/example@email.com
        [HttpPut]
        public async Task<ActionResult<Customer>> PutCustomer(Customer customer)
        {
            var updatedCustomer = await _context.Customers
                                                .Where(c => c.EmailOfCompanyContact == customer.EmailOfCompanyContact)
                                                .FirstOrDefaultAsync();

            if (updatedCustomer == null)
            {
                return NotFound();
            }

            updatedCustomer.CompanyName = customer.CompanyName;
            updatedCustomer.FullNameOfCompanyContact = customer.FullNameOfCompanyContact;
            updatedCustomer.CompanyContactPhone = customer.CompanyContactPhone;
            updatedCustomer.FullNameOfServiceTechnicalAuthority = customer.FullNameOfServiceTechnicalAuthority;
            updatedCustomer.TechnicalAuthorityPhoneForService = customer.TechnicalAuthorityPhoneForService;
            updatedCustomer.TechnicalManagerEmailForService = customer.TechnicalManagerEmailForService;
            updatedCustomer.CompanyDescription = customer.CompanyDescription;

            await _context.SaveChangesAsync();

            return updatedCustomer;
        }
    }
}