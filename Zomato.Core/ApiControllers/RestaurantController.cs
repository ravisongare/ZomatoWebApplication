using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.RestaurantRepo;
using Zomato.Repository.UnitOfWork;

namespace Zomato.Core.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        #region Dependencies
     //   private readonly IRestaurantRepository _restaurantRepo;
        private readonly IUnitOfWork _UnitOfWork;
        #endregion

        #region constructor
        public RestaurantController(IUnitOfWork _unitOfWork)
        {
         //   _restaurantRepo = restaurantRepo;
            _UnitOfWork = _unitOfWork;
        }
        #endregion
        // Get: api/restaurant
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurant()
        {
            return await _UnitOfWork.RestaurantRepository.GetAllRestaurant();
        }
        // Post: api/restaurant
        [HttpPost]
        public async Task<ActionResult> AddRestaurant([FromBody] Restaurant restaurant)
        {
            await _UnitOfWork.RestaurantRepository.AddRestaurant(restaurant);
            return Ok();
        }
        // Get: api/restaurant/5
        [HttpGet, Route("{id}")]
        public async Task<Restaurant> getRestaurant([FromRoute]int id)
        {
            return await _UnitOfWork.RestaurantRepository.GetRestaurantById(id);
        }
        // Post: api/restaurant/menus
        [HttpPost, Route("menus")]
        public async Task<ActionResult> AddMenu([FromBody] Menu menu)
        {
            await _UnitOfWork.RestaurantRepository.AddMenu(menu);
            return Ok();
        }
        // get: api/restaurant/menus/id
        [HttpGet, Route("menus/{id}")]
        public async Task<Menu> GetMenuById([FromRoute] int id)
        {
            return await _UnitOfWork.RestaurantRepository.GetManuById(id);
        }
        // Get: api/restaurant/5/menus
        [HttpGet, Route("{id}/menus")]
        public async Task<List<Menu>> GetMenuByRestaurant([FromRoute] int id)
        {
            return await _UnitOfWork.RestaurantRepository.GetManuByrestaurant(id);
        }
        // Post: api/restaurant/reviews
        [HttpPost, Route("reviews")]
        public async Task<ActionResult> AddReview([FromBody] Review review)
        {
            await _UnitOfWork.RestaurantRepository.AddReview(review);
            return Ok();
        }
        // Get: api/restaurant/5/reviews
        [HttpGet, Route("{id}/reviews")]
        public async Task<List<Review>> GetReviewsByRestaurantId([FromRoute]int id)
        {
           return await _UnitOfWork.RestaurantRepository.GetReviewsByRestaurantId(id);
        }
        // Post: api/restaurant/comment
        [HttpPost, Route("review/comments")]
        public async Task<ActionResult> Addcomment([FromBody] Comment comment)
        {
            await _UnitOfWork.RestaurantRepository.AddComment(comment);
            return Ok();
        }
        // Get: api/restaurant/reviews/5/comments
        [HttpGet, Route("reviews/{id}/comments")]
        public async Task<List<Comment>> GetCommentByReviewId([FromRoute]int id)
        {
            return await _UnitOfWork.RestaurantRepository.GetCommentByReviewId(id);
        }
        [HttpPost, Route("reviews/comments/like")]
        public async Task<ActionResult> AddLike([FromBody] Like like)
        {
            await _UnitOfWork.RestaurantRepository.AddLike(like);
            return Ok();
        }
        // Get: api/restaurant/5/likes
        [HttpGet, Route("reviews/comments/{id}/likes")]
        public async Task<int> GetLikeByCommentId([FromRoute]int id)
        {
            return await _UnitOfWork.RestaurantRepository.GetLikeByCommentId(id);
        }

       
    }
}
