namespace Rocket_Rest.Models
{
    public class Customer
    {
        public long id { get; set; }
        public string company_name  { get; set; }
        public string full_name  { get; set; }
        public long? lead_id {get; set; }
    }
}