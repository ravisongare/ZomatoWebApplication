using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.OrderRepo;
using Zomato.Repository.UnitOfWork;

namespace Zomato.Core.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementController : Controller
    {
        #region Dependencies
        //private readonly IOrderRepository _OrderRepo;
        private readonly IUnitOfWork _UnitOfWork;
        #endregion

        #region controller
        public OrderManagementController(IUnitOfWork _unitOfWork)
        {
           // _OrderRepo = orderRepo;
            _UnitOfWork = _unitOfWork;
        }
        #endregion

        #region Public Methods
        //Post: OrderManagement/items
        [HttpPost, Route("items")]
        public async Task<ActionResult> AddItem([FromBody] Item item)
        {
          await _UnitOfWork.OrderRepository.AddItem(item);
           
            return Ok();
        }
        // get: api/ordermanagement/menus/id/items
        [HttpGet, Route("menus/{id}/items")]
        public async Task<List<Item>> GetItemsByMenuId([FromRoute] int id)
        {
            return await _UnitOfWork.OrderRepository.GetItemsbyMenu(id);
        }
        // Get: api/ordermanagement/items/id
        [HttpGet, Route("items/{id}")]
        public async Task<Item> GetItemById([FromRoute] int id)
        {
            return await _UnitOfWork.OrderRepository.GetItemById(id);
        }

        //Post: OrderManagement/orders
        [HttpPost, Route("orders")]
        public async Task<ActionResult> AddOrder([FromBody] Order order)
        {
            await _UnitOfWork.OrderRepository.AddOrder(order);
            return Ok();
        }
        // get: api/ordermanagement/users/id/orders
        [HttpGet, Route("users/{id}/orders")]
        public async Task<List<Order>> GetOrderByUser([FromRoute] string id)
        {
            return await _UnitOfWork.OrderRepository.GetOrderByUserId(id);
        }


        //Post: OrderManagement/selecteditems
        [HttpPost, Route("orders")]
        public async Task<ActionResult> AddSelectedItems([FromBody] SelectedItem selectedItem)
        {
            await _UnitOfWork.OrderRepository.AddSelecteditem(selectedItem);
            return Ok();
        }
        // get: api/ordermanagement/order/id/items
        [HttpGet, Route("menus/{id}/items")]
        public async Task<List<SelectedItem>> GetOrderByUser([FromRoute] int id)
        {
            return await _UnitOfWork.OrderRepository.GetItemsByOrderId(id);
        }

        #endregion
    }
}
