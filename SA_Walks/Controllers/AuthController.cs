using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SA_Walks.API.Models.DTO;
using SA_Walks.API.Repositories;

namespace SA_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // This controller is responsible for handling authentication-related actions.
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        //User management

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)

        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        // POST: api/auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok(new { Message = "User registered successfully" });
                    }
                    
                }
            }
            // If we reach here, something went wrong
            return BadRequest("Something went wrong");
                             
        }

        // POST: api/auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResults = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResults)
                {
                    //Get the roles for the user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                         //Create JWT token

                         var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                         var response = new LoginResponseDto
                         {
                             JwtToken = jwtToken
                         };

                         return Ok(response);

                    }
                                                        
                }
            }
            return BadRequest("Invalid username or password");
        }
    }
}
