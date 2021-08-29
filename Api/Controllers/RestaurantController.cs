using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sion.BurgerBackend.Api.Model;
using Sion.BurgerBackend.BusinessLogic.Entities;
using Sion.BurgerBackend.DataAccess;

namespace Sion.BurgerBackend.Api.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly BurgerBackendDbContext _db;

        public RestaurantController(BurgerBackendDbContext db)
        {
            _db = db;
        }

        [HttpGet("/api/restaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            var allRestaurants = await _db.Restaurants.Include(x => x.Burgers).ToListAsync();

            var mappedRestaurants = allRestaurants
                .Select(r => new GetRestaurantResponse(r.Id, r.Name, MapBurgers(r.Burgers)));

            return Ok(mappedRestaurants);
        }

        [HttpGet("/api/restaurants/{restaurantId}")]
        public async Task<IActionResult> GetRestaurant(Guid restaurantId)
        {
            var restaurant = await _db.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurantId);

            if (restaurant is null)
            {
                return NotFound();
            }

            return Ok(new GetRestaurantResponse(restaurant.Id, restaurant.Name, MapBurgers(restaurant.Burgers)));
        }

        private static List<GetBurgerResponse> MapBurgers(List<Burger> burgers)
        {
            return burgers.Select(b => new GetBurgerResponse(b.Id, b.Name, MapReviews(b.Reviews))).ToList();
        }

        private static List<GetReviewResponse> MapReviews(List<Review> reviews)
        {
            return reviews.Select(r => new GetReviewResponse(r.User.Username, r.TasteScore, r.TextureScore, r.VisualScore)).ToList();
        }
    }
}
