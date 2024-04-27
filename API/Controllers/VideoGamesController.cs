using Infrastructure.Entities;
using Infrastructure.Services.Implementations;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGames _videoGamesService;

        public VideoGamesController(IVideoGames videoGamesService)
        {
            _videoGamesService = videoGamesService;
        }


        [HttpGet]
        [Route("getGames")]

        public async Task<IActionResult> GetAllGamesAsync()
        {
            var result = await _videoGamesService.GetAllAsync<Game>();

            return Ok(result);
        }

    }
}
