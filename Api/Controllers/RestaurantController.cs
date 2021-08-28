using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sion.BurgerBackend.Api.Model;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRestaurants()
        {
            var allRestaurants = await _db.Restaurants.Include(x => x.Burgers).ToListAsync();

            var mappedRestaurants = allRestaurants
                .Select(r => new GetRestaurantsResponse(r.Burgers
                    .Select(b => new GetBurgerResponse(b.Name))
                    .ToList()));

            return Ok(mappedRestaurants);
        }
    }
}
