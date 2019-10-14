using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class ZomatoDbContext:IdentityDbContext<ApplicationUser>
    {
        public ZomatoDbContext(DbContextOptions<ZomatoDbContext> options) : base(options)
        { }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SelectedItem> SelectedItems { get; set; }
       // public DbSet<User> Users { get; set; }
    }
}
