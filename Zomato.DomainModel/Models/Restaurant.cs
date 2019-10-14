using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime Timing { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public DateTime DeleiveryTime { get; set; }
        public int MinimumOrder { get; set; }
        public int Rating { get; set; }
    }
}
