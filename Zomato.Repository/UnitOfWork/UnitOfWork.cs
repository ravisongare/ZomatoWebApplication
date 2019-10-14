using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;
using Zomato.Repository.AccountRepo;
using Zomato.Repository.OrderRepo;
using Zomato.Repository.RestaurantRepo;

namespace Zomato.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Dependencies
        public IRestaurantRepository RestaurantRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        #endregion

        #region  Constructors
        public UnitOfWork( IRestaurantRepository restaurantRepository,IAccountRepository accountRepository,IOrderRepository orderRepository)
        {
            RestaurantRepository = restaurantRepository;
            AccountRepository = accountRepository;
            OrderRepository = orderRepository;
        }

        public void commit()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}