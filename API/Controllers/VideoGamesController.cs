using API.DTO_s;
using AutoMapper;
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

        private readonly IMapper _mapper;
        public VideoGamesController(IVideoGames videoGamesService, IMapper mapper)
        {
            _videoGamesService = videoGamesService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("getGames")]

        public async Task<IActionResult> GetAllGamesAsync([FromQuery] int pageSize = 2, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Game>(pageSize,pageNumber);
            
            if(result != null)
                return Ok(result.Select(_mapper.Map<GameDTO>));
            else
                return NotFound();
        }



    }
}
