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
        
         public IEnumerable<Lead> GetLead()
        {   
            
            IQueryable<Lead> result = from l in _context.leads  
                join c in _context.customers on l.id equals c.lead_id into p
                from c in p.DefaultIfEmpty()


                where l.created_at >= DateTime.Now.AddDays(-30) 
                where (c.lead_id == null)
                select l;

            return result;
            
        }
    }
}