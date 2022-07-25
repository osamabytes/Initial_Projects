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
    public class BookshopController : Controller
    {
        private readonly BookifyDbContext _BookifyDbContext;
        private readonly UserManager<User> _UserManager;

        public BookshopController(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _BookifyDbContext = bookifyDbContext;
            _UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AllBookShops()
        {
            var useremail = User.Claims.FirstOrDefault();
            if (useremail == null)
                return NotFound();

            var user = await _UserManager.FindByEmailAsync(useremail.Value);

            if (user == null)
                return Unauthorized(new GeneralAuthResponseDto
                {
                    IsAllowed = false,
                    Errors = new List<string> { "User Not Logged In" }
                });

            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _BookifyDbContext);
            if(ut.TypeId == AppConfig.SuperAdminGuid)
            {
                List<User_Bookshop> user_Bookshops = User_Bookshop.All(_BookifyDbContext);
                
                foreach(var bookshop in user_Bookshops)
                {
                    var u = await _UserManager.FindByIdAsync(bookshop.UserId.ToString());
                    var bs = Bookshop.GetById(bookshop.BookshopId, _BookifyDbContext);

                    bookshop.User = u;
                    bookshop.Bookshop = bs;
                }

                return Ok(user_Bookshops);
            }

            return Unauthorized(new GeneralAuthResponseDto
            {
                IsAllowed = false,
                Errors = new List<string> { "User not allowed for this feature" }
            });
        }

        
        [HttpPost]
        public async Task<IActionResult> AddBookshop([FromBody] Bookshop bookshop)
        {
            var useremail = User.Claims.FirstOrDefault();
            if (useremail == null) 
                return NotFound();

            var user = await _UserManager.FindByEmailAsync(useremail.Value);

            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _BookifyDbContext);

            if (ut.TypeId == AppConfig.AdminGuid)
            {
                Bookshop bs = new Bookshop();
                bs.Name = bookshop.Name;

                await bs.Save(_BookifyDbContext);

                User_Bookshop user_Bookshop = new User_Bookshop();
                user_Bookshop.UserId = user.Id;
                user_Bookshop.BookshopId = bs.Id;

                await user_Bookshop.Save(_BookifyDbContext);

                return Ok(bs);
            }

            return Unauthorized(new GeneralAuthResponseDto
            {
                IsAllowed = false,
                Errors = new List<string> { "User not allowed for this feature" }
            });
        }
    }
}
