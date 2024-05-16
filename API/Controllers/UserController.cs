using API.DTO_s.User_RolesDTO_s;
using Core.Login_RegisterDTO_s;
using Infrastructure.Services.Interfaces;
using Infrastructure.User_RolesDTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccount _service;

        public UserController(IUserAccount service)
        {
            _service = service;
        }


        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> RegisterUser(RegisterDTO dto)
        {
            if (dto == null) return BadRequest("dto cannot be null");

            await _service.CreateAsync(dto);

            return Created();
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> LoginUser(LoginDTO dto)
        {
            if (dto == null) return BadRequest("dto cannot be null");

            var token = await _service.LoginAsync(dto);

            return Ok(token); //returns token if user successfully login
        }


        [HttpPost]
        [Route("refresh_token")]

        public async Task<IActionResult> RefreshToken(RefreshTokenDTO dto)
        {
            if (dto == null) return BadRequest("dto cannot be null");

            var token = await _service.RefreshTokenAsync(dto);

            return Ok(token.Token);
        }
    }
}
