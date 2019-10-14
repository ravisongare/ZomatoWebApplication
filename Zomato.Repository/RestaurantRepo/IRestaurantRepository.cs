using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantRepo
{
    public interface IRestaurantRepository
    {
        Task AddRestaurant(Restaurant restaurant);
        Task<List<Restaurant>> GetAllRestaurant();
        Task<Restaurant> GetRestaurantById(int id);
        Task AddMenu(Menu menu);
        Task<List<Menu>> GetManuByrestaurant(int id);
        Task<Menu> GetManuById(int id);
        Task AddReview(Review review);
        Task<List<Review>> GetReviewsByRestaurantId(int restaurantId);
        Task AddComment(Comment comment);
        Task<List<Comment>> GetCommentByReviewId(int reviewId);
        Task AddLike(Like like);
        Task<int> GetLikeByCommentId(int commentId);


    }
}
