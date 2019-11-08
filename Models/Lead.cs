using System;

namespace Rocket_Rest.Models
{
    public class Lead
    {
        public long id { get; set; }
        public DateTime created_at { get; set; }
        
        public string full_name {get; set;}
    }
}