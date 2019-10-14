using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }
    }
}
