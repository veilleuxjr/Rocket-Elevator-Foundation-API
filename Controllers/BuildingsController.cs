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
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly Rocket_RestContext _context;

        public BuildingsController(Rocket_RestContext context)
        {
            _context = context;
        }

        
        // GET: api/buildings -- will get buildings with a battery, column or elevator that is getting an intervention
        
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
        
            IQueryable<Building> status = (from buildings in _context.buildings
                join batStatus in _context.batteries on buildings.id equals batStatus.building_id
                join colStatus in _context.columns on batStatus.id equals colStatus.battery_id
                join eleStatus in _context.elevators on colStatus.id equals eleStatus.column_id
           
                    where batStatus.status == "Intervention" || colStatus.status == "Intervention" || eleStatus.status == "Intervention"
                    
                    select buildings).Distinct();
           
            
            return await _context.buildings.ToListAsync();
           
         
        }
    }
}