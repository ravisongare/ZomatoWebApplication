using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepo
{
    public interface IOrderRepository
    {
        Task AddItem(Item item);
        Task<List<Item>> GetItemsbyMenu(int menuId);
        Task<Item> GetItemById(int itemId);
        Task AddOrder(Order order);
        Task<List<Order>> GetOrderByUserId(string userId);
        Task AddSelecteditem(SelectedItem selectedItem);
        Task<List<SelectedItem>> GetItemsByOrderId(int orderId);
    }
}
