using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenHandler _tokenHandler;
        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult>Register(RegisterRequestDTO registerRequestDTO)
        {
            User user=new User() { Email=registerRequestDTO.Email , UserName=registerRequestDTO.Email};
            var result=await _userManager.CreateAsync(user,registerRequestDTO.Password);
            if(result.Succeeded )
            {
                if( registerRequestDTO.Roles.Any())
                {
                    foreach(var role in registerRequestDTO.Roles)
                    {
                        if(!await _roleManager.RoleExistsAsync(role))
                        {
                            Role newRole=new Role() { Name=role};
                            await _roleManager.CreateAsync(newRole);
                        }
                    }
                    var result2 = await _userManager.AddToRolesAsync(user, registerRequestDTO.Roles);
                    if (result2.Succeeded)
                    {
                        return Ok("Registered Success");
                    }
                    else
                    {
                        return BadRequest(result2.Errors);
                    }
                }
                else
                {
                    return Ok("Registered Success");
                }
                
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            User? user = await _userManager.FindByEmailAsync(loginRequest.Username);
            if (user!=null)
            {
                bool CheckPassword= await _userManager.CheckPasswordAsync(user, loginRequest.Password);
                if (CheckPassword)
                {
                    string token = await _tokenHandler.CreateTokenAsync(user,await _userManager.GetRolesAsync(user));
                    return Ok(token);
                }
            }
            return Unauthorized("Wrong Email Or Password");

        }
    }
}
