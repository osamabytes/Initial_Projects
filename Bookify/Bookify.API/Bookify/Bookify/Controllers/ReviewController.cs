using Bookify.Constants;
using Bookify.Data;
using Bookify.Dto;
using Bookify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;

        public ReviewController(UserManager<User> userManager, BookifyDbContext bookifyDbContext)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            var userEmail = User.Claims.FirstOrDefault();

            if (userEmail == null)
                return NotFound();

            var user = await _userManager.FindByEmailAsync(userEmail.Value);

            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);

            if(ut.TypeId == AppConfig.CustomerGuid) {
                if (Review.GetbyUserandBook(review.UserId, review.Bookid, _bookifyDbContext) == null)
                {
                    Review r = new Review();
                    r.Rating = review.Rating;
                    r.Reviews = review.Reviews;

                    r.UserId = review.UserId;
                    r.Bookid = review.Bookid;

                    await r.Save(_bookifyDbContext);

                    return Ok(r);
                }
                else
                {
                    return BadRequest(
                        new GeneralAuthResponseDto
                        {
                            IsAllowed = false,
                            Errors = new List<string> { "Review already Submitted" }
                        }
                    );
                }
            }

            return Unauthorized(
                new GeneralAuthResponseDto
                {
                    IsAllowed = false,
                    Errors = new List<string> { "User not allowed for this feature" }
                }
            );
        }
    }
}
