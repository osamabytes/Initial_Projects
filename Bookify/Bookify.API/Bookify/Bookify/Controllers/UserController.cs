using AutoMapper;
using Bookify.Dto;
using Bookify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [ApiController ]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager=userManager;
            _mapper=mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            if (userRegistrationDto == null || !ModelState.IsValid)
                return BadRequest();

            userRegistrationDto.Id = Guid.NewGuid();

            var user = _mapper.Map<User>(userRegistrationDto);
            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegisterResponseDto { Errors = errors, IsSuccessfulRegister = false });
            }

            return Ok(new RegisterResponseDto { IsSuccessfulRegister = true});

        }
    }
}
