using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sion.BurgerBackend.Api.Model;
using Sion.BurgerBackend.BusinessLogic.Entities;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;
using Sion.BurgerBackend.DataAccess;

namespace Sion.BurgerBackend.Api.Controllers
{
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly BurgerBackendDbContext _db;

        public ReviewsController(BurgerBackendDbContext db)
        {
            _db = db;
        }

        [HttpPost("/api/reviews")]
        public async Task<IActionResult> CreateReview(CreateReviewRequest request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            var burger = await _db.Burgers.FirstOrDefaultAsync(x => x.Id == request.BurgerId);

            // TODO: Message to let consumer know which failed
            if (burger is null || user is null)
            {
                return NotFound();
            }

            var result = await _db.Reviews.AddAsync(new Review(
                user,
                burger,
                (Rating)request.TasteScore,
                (Rating)request.TextureScore,
                (Rating)request.VisualScore
            ));

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
