using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
    }
}
