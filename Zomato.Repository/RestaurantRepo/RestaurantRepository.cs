using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantRepo
{
    public class RestaurantRepository:IRestaurantRepository
    {
        #region Dependencies
        private readonly ZomatoDbContext _db;
        #endregion


        #region Constructor
        public RestaurantRepository(ZomatoDbContext db){
            this. _db = db;
        }
        #endregion

        #region Public methods
        public async Task AddRestaurant(Restaurant restaurant)
        {
          await _db.Restaurants.AddAsync(restaurant);

           _db.SaveChanges();
        }
        public async Task<List<Restaurant>> GetAllRestaurant()
        {
            var t = _db.Restaurants.ToListAsync();
            return  await t;
        }
        public async Task<Restaurant> GetRestaurantById(int id)
        {
          return await _db.Restaurants.Where(res => res.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddMenu(Menu menu)
        {
            await _db.Menus.AddAsync(menu);
            _db.SaveChanges();
        }
        public async Task<List<Menu>> GetManuByrestaurant(int restaurantId)
        {
            return await _db.Menus.Where(menu => menu.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<Menu> GetManuById(int id)
        {
            return await _db.Menus.SingleOrDefaultAsync<Menu>(menu => menu.Id == id);
        }
        public async Task AddReview(Review review)
        {
            await _db.Reviews.AddAsync(review);
            _db.SaveChanges();
        }
        public async Task<List<Review>>GetReviewsByRestaurantId(int restaurantId)
        {
           return await _db.Reviews.Where(review => review.RestaurantId == restaurantId).ToListAsync<Review>();
        }
        public async Task AddComment(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            _db.SaveChanges();
        }
        public async Task<List<Comment>> GetCommentByReviewId(int reviewId)
        {
            return await _db.Comments.Where(comment => comment.ReviewId == reviewId).ToListAsync<Comment>();
        }
        public async Task AddLike(Like like)
        {
            await _db.Likes.AddAsync(like);
            _db.SaveChanges();
        }
        public async Task<int> GetLikeByCommentId(int commentId)
        {
            return await _db.Likes.CountAsync(r => r.CommentId == commentId);
        }
        #endregion
    }
}
