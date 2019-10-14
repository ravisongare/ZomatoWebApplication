using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string UserId { get; set; }
        public int Like { get; set; } = 0;
        public string Description { get; set; }
    }
}
