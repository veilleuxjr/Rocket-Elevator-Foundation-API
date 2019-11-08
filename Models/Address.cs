namespace Rocket_Rest.Models
{
    public class Address
    {
        public long id { get; set; }
        public string type_of_address { get; set; }
        public string status { get; set; }
        public string entity { get; set; }
        public string number_and_street { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        
    }
}