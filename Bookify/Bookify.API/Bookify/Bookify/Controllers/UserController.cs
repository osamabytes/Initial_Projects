using AutoMapper;
using Bookify.Data;
using Bookify.Dto;
using Bookify.JwtBearer;
using Bookify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Bookify.Controllers
{
    [ApiController]
    [AllowAnnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public UserController(UserManager<User> userManager, BookifyDbContext bookifyDbContext, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager=userManager;
            _bookifyDbContext=bookifyDbContext;
            _mapper =mapper;
            _jwtHandler = jwtHandler;
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

            // Save UserType

            // Get Type for the user
            Models.Type type = Models.Type.GetById(userRegistrationDto.TypeId, _bookifyDbContext);

            User_Type userType = new User_Type();
            userType.UserId = user.Id;
            userType.TypeId = type.Id;

            await userType.Save(_bookifyDbContext);


            return Ok(new RegisterResponseDto { IsSuccessfulRegister = true });

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (userForAuthenticationDto == null || !ModelState.IsValid)
                return BadRequest();

            // check if the user exists in the system
            var user = await _userManager.FindByNameAsync(userForAuthenticationDto.Email);

            if (user == null)
                return Unauthorized(new AuthenticationResponseDto { IsAuthSuccessful = false, ErrorMessage = "Invalid User SignIn" });

            // authorize user with email and password
            var authUser = await _userManager.CheckPasswordAsync(user, userForAuthenticationDto.Password);
            if (!authUser)
            {
                return Unauthorized(new AuthenticationResponseDto { IsAuthSuccessful = false, ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthenticationResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [HttpGet("GetUserType")]
        public async Task<IActionResult> GetUserType()
        {
            var useremail = User.Claims.FirstOrDefault();

            if (useremail == null)
                return Unauthorized(
                    new GeneralAuthResponseDto
                    {
                        IsAllowed = false,
                        Errors = new List<string> { "User Not Logged In" }
                    }
                );

            var user = await _userManager.FindByEmailAsync(useremail.Value);

            if (user == null)
                return NotFound();

            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);
            Models.Type type = Models.Type.GetById(ut.TypeId, _bookifyDbContext);

            return Ok(type);
        }
    }
}
