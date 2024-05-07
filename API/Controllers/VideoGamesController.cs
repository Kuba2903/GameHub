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

        ///GET ENDPOINTS
        #region

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

        #endregion

        ///POST ENDPOINTS
        #region
        [HttpPost]
        [Route("addGame")]

        public async Task<IActionResult> AddGameAsync(GameDTO dto)
        {
            var mapped = _mapper.Map<Game>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGenre")]

        public async Task<IActionResult> AddGenreAsync(GenreDTO dto)
        {
            var mapped = _mapper.Map<Genre>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }

        [HttpPost]
        [Route("addPublishers")]

        public async Task<IActionResult> AddPublishersAsync(PublisherDTO dto)
        {
            var mapped = _mapper.Map<Publisher>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGame_Publisher")]

        public async Task<IActionResult> AddGame_PublisherAsync(Game_PublisherDTO dto)
        {
            var mapped = _mapper.Map<Game_Publisher>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addPlatform")]

        public async Task<IActionResult> AddPlatformAsync(PlatformDTO dto)
        {
            var mapped = _mapper.Map<Platform>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGame_Platform")]

        public async Task<IActionResult> AddGame_PlatformAsync(Game_PlatformDTO dto)
        {
            var mapped = _mapper.Map<Game_Platform>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addRegion")]

        public async Task<IActionResult> AddRegionAsync(RegionDTO dto)
        {
            var mapped = _mapper.Map<Region>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addRegion_Sales")]

        public async Task<IActionResult> AddRegion_SalesAsync(Region_SalesDTO dto)
        {
            var mapped = _mapper.Map<Region_Sales>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }

        #endregion
    }
}
