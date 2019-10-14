using System;
using System.Collections.Generic;
using System.Text;
using Zomato.Repository.AccountRepo;
using Zomato.Repository.OrderRepo;
using Zomato.Repository.RestaurantRepo;

namespace Zomato.Repository.UnitOfWork
{
  public interface IUnitOfWork
    {
       IRestaurantRepository RestaurantRepository { get; set; }
        IAccountRepository AccountRepository{ get; set; }
        IOrderRepository OrderRepository { get; set; }
        void commit();
    }
}
