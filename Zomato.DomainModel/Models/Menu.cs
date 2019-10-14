using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
     public class Menu
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Type { get; set; }

    }
}
