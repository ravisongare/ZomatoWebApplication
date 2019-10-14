using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        #region Dependencies
        private readonly ZomatoDbContext _db;
        #endregion

        #region Constructors
        public OrderRepository(ZomatoDbContext zomatoDbContext )
        {
            _db = zomatoDbContext;
        }
        #endregion

 
        #region Public Methods

        public async Task AddItem(Item item)
        {
            await _db.Items.AddAsync(item);
         await _db.SaveChangesAsync();
        }
        public async Task<List<Item>> GetItemsbyMenu(int menuId)
        {
          return await _db.Items.Where(item => item.MenuId == menuId).ToListAsync();
        }
        public async Task<Item> GetItemById(int itemId)
        {
          return await _db.Items.SingleOrDefaultAsync(Item => Item.Id == itemId);
        }


        public async Task AddOrder(Order order)
        {
           await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Order>> GetOrderByUserId(string userId)
        {
          return await  _db.Orders.Where(order => order.UserId == userId).ToListAsync();
        }


        public async Task AddSelecteditem(SelectedItem selectedItem)
        {
            await _db.SelectedItems.AddAsync(selectedItem);
            await _db.SaveChangesAsync();
        }
        public async Task<List<SelectedItem>> GetItemsByOrderId(int orderId)
        {
           return await _db.SelectedItems.Where(items => items.OrderId == orderId).ToListAsync();
        }
        #endregion
    }
}
