using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public string Password { get; set; }
    }
}
