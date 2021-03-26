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
    public class LeadnotCustomer : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        // Get: api/LeadnotCustomer
        public LeadnotCustomer(RailsApp_developmentContext context)
        {
            _context = context;
        }
        
        //GET: api/LeadnotCustomer/all_lead
        //List of all the the leads
        [HttpGet ("all_lead")]
        public ActionResult<List<Lead>> GetLeads()
        {
            return _context.Leads.ToList();       
        }

        //IEnumarable and IQuerably: 
        // GET: api/LeadnotCustomer/lastmonth
        [HttpGet ("lastmonth")]
        public ActionResult<IEnumerable<Lead>> GetRecent()
        {
            //Storing "in the the last 30 days" into variable lastmonth
            var lastmonth = DateTime.Now.AddDays(-30);
            // Creation of the list
            IQueryable<Lead> leadlist = from lead in _context.Leads
            where lead.CreatedAt >= lastmonth && lead.CustomerId == null
            select lead;
            return leadlist.ToList();        
        }
        
    }
}