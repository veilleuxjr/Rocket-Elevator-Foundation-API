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
    [Route("api/elevatorsStatus")]
    [ApiController]
    public class ElevatorsStatusController : ControllerBase
    {
        private readonly Rocket_RestContext _context;

        public ElevatorsStatusController(Rocket_RestContext context)
        {
            _context = context;
        }


        // GET: api/elevatorsStatus

        public IEnumerable<Elevator> GetElevatorsStatus()
        {
        
            IQueryable<Elevator> status = from eStatus in _context.elevators where eStatus.status == "Inactive" || eStatus.status == "Intervention" select eStatus;
            
            return status;
        }
    }
}