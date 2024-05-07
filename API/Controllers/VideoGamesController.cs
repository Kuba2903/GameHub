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

        public async Task<IActionResult> GetAllGamesAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Game>(pageSize,pageNumber);
            
            if(result != null)
                return Ok(result.Select(_mapper.Map<GameDTO>));
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getGenres")]

        public async Task<IActionResult> GetAllGenresAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Genre>(pageSize,pageNumber);

            if(result != null)
                return Ok(result.Select(_mapper.Map<GenreDTO>));
            else
                return NotFound();
        }


        [HttpGet]
        [Route("getPublishers")]

        public async Task<IActionResult> GetAllPublishersAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Publisher>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<PublisherDTO>));
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getGame_Publisher")]

        public async Task<IActionResult> GetAllGame_PublisherAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Game_Publisher>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<Game_PublisherDTO>));
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getPlatform")]

        public async Task<IActionResult> GetAllPlatformAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Platform>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<PlatformDTO>));
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getGame_Platform")]

        public async Task<IActionResult> GetAllGame_PlatformAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Game_Platform>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<Game_PlatformDTO>));
            else
                return NotFound();
        }


        [HttpGet]
        [Route("getRegion")]

        public async Task<IActionResult> GetAllRegionAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Region>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<RegionDTO>));
            else
                return NotFound();
        }


        [HttpGet]
        [Route("getRegionSales")]

        public async Task<IActionResult> GetAllRegion_SalesAsync([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            if (pageSize < 1 || pageNumber < 1)
                return BadRequest("pageSize or pageNumber must be greater than 0!");

            var result = await _videoGamesService.GetAllAsync<Region_Sales>(pageSize, pageNumber);

            if (result != null)
                return Ok(result.Select(_mapper.Map<Region_SalesDTO>));
            else
                return NotFound();
        }
    }
}
