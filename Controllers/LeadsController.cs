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
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly Rocket_RestContext _context;

        public LeadsController(Rocket_RestContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.leads.ToListAsync();
        }

        [HttpGet("under30")]
        // public IEnumerable<Lead> GetLead()
        // {

        // }
         public IEnumerable<Lead> GetLead()
        {   
            
            IQueryable<Lead> result = (from t in _context.leads
                join r in _context.customers on t.id equals r.lead_id

                where t.created_at >= DateTime.Now.AddDays(-30) && r == null select t);

            return result;
            
        }
    }
}