using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }

    }
}
