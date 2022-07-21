using Bookify.Constants;
using Bookify.Data;
using Bookify.Dto;
using Bookify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
