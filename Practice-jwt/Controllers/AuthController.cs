using Microsoft.AspNetCore.Mvc;
using Practice_jwt.Abstract;
using Practice_jwt.Dtos;
using Practice_jwt.Models;

namespace Practice_jwt.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService= tokenService;
        }

        [HttpPost]
        public IActionResult CreateToken(LoginDto loginDto)
        {
            var result = _tokenService.CreateToken(new UserApp
            {
                Email = loginDto.Email
            });
            return Ok(result);
        }
    }
}
