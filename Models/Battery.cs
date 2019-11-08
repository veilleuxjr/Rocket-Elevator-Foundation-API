namespace Rocket_Rest.Models
{
    public class Battery
    {
        public long id { get; set; }
        public string status { get; set; }
        public long building_id {get; set;}
        public string type_of_battery { get; set; }
    }
}