namespace Rocket_Rest.Models
{
    public class Building
    {
        public long id { get; set; }
        public string admin_full_name { get; set; }
        public long customer_id {get; set; }
        public long address_id {get; set; }
    }
}