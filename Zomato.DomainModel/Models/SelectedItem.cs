using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class SelectedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public int count { get; set; }
        public int Amount { get; set; }
    }
}
