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
    public class CategoryController : Controller
    {
        private readonly BookifyDbContext _bookifyDbContext;
        private readonly UserManager<User> _userManager;
        
        public CategoryController(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _bookifyDbContext = bookifyDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var useremail = User.Claims.FirstOrDefault();

            if (useremail == null)
                return NotFound();

            var user = await _userManager.FindByEmailAsync(useremail.Value);

            // Get User Type
            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);

            if(ut.TypeId == AppConfig.SuperAdminGuid || ut.TypeId == AppConfig.AdminGuid)
            {
                List<Category> categories = Category.GetAllCategories(_bookifyDbContext);
                return Ok(categories);
            }

            return Unauthorized(new GeneralAuthResponseDto { 
                IsAllowed = false,
                Errors = new List<string>() { "User not allowed for this feature" }
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            var useremail = User.Claims.FirstOrDefault();

            if (useremail == null)
                return NotFound();

            var user = await _userManager.FindByEmailAsync(useremail.Value);

            // Get User type
            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);


            // check the type of the user is Super Admin
            if(ut.TypeId == AppConfig.SuperAdminGuid)
            {
                Category c = new Category();
                c.Name = category.Name;
                c.Description = category.Description;

                await c.Save(_bookifyDbContext);

                return Ok(c);
            }

            return Unauthorized(new GeneralAuthResponseDto { 
                IsAllowed = false,
                Errors = new List<string> { "User not allowed for this feature" }
            });
        }
    }
}
