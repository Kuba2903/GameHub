using API.Add_DTO_s;
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

        public async Task<IActionResult> AddGameAsync(AddGameDTO dto)
        {
            var mapped = _mapper.Map<Game>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGenre")]

        public async Task<IActionResult> AddGenreAsync(AddGenreDTO dto)
        {
            var mapped = _mapper.Map<Genre>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }

        [HttpPost]
        [Route("addPublishers")]

        public async Task<IActionResult> AddPublishersAsync(AddPublisherDTO dto)
        {
            var mapped = _mapper.Map<Publisher>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGame_Publisher")]

        public async Task<IActionResult> AddGame_PublisherAsync(AddGame_PublisherDTO dto)
        {
            var mapped = _mapper.Map<Game_Publisher>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addPlatform")]

        public async Task<IActionResult> AddPlatformAsync(AddPlatformDTO dto)
        {
            var mapped = _mapper.Map<Platform>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addGame_Platform")]

        public async Task<IActionResult> AddGame_PlatformAsync(AddGame_PlatformDTO dto)
        {
            var mapped = _mapper.Map<Game_Platform>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addRegion")]

        public async Task<IActionResult> AddRegionAsync(AddRegionDTO dto)
        {
            var mapped = _mapper.Map<Region>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }


        [HttpPost]
        [Route("addRegion_Sales")]

        public async Task<IActionResult> AddRegion_SalesAsync(AddRegion_SalesDTO dto)
        {
            var mapped = _mapper.Map<Region_Sales>(dto);

            await _videoGamesService.AddAsync(mapped);

            return Ok("Added record to the database");
        }

        #endregion


        ///DELETE ENDPOINTS
        #region
        [HttpDelete]
        [Route("deleteGame")]

        public async Task<IActionResult> DeleteGame(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Game>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");
            
        }

        [HttpDelete]
        [Route("deleteGenre")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Genre>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }


        [HttpDelete]
        [Route("deletePublishers")]
        public async Task<IActionResult> DeletePublishers(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Publisher>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }


        [HttpDelete]
        [Route("deleteGame_Publishers")]
        public async Task<IActionResult> DeleteGame_Publishers(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Game_Publisher>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }



        [HttpDelete]
        [Route("deletePlatform")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Platform>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }


        [HttpDelete]
        [Route("deleteGame_Platform")]
        public async Task<IActionResult> DeleteGame_Platform(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Game_Platform>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }

        [HttpDelete]
        [Route("deleteRegion")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Region>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }

        [HttpDelete]
        [Route("deleteRegion_Sales")]
        public async Task<IActionResult> DeleteRegion_Sales(int id)
        {
            var entity = await _videoGamesService.FindByIdAsync<Region_Sales>(id);

            if (entity != null)
            {
                await _videoGamesService.RemoveAsync(entity);
                return Ok("Record removed");
            }
            else
                return NotFound($"Record with {id} id not found");

        }
        #endregion

        ///PUT ENDPOINTS
        #region

        [HttpPut]
        [Route("updateGame")]

        public async Task<IActionResult> UpdateGame(GameDTO dto)
        {
            var mapped = _mapper.Map<Game>(dto);
            
            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }


        [HttpPut]
        [Route("updateGenres")]

        public async Task<IActionResult> UpdateGenre(GenreDTO dto)
        {
            var mapped = _mapper.Map<Genre>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }


        [HttpPut]
        [Route("updatePublisher")]
        public async Task<IActionResult> UpdatePublisher(PublisherDTO dto)
        {
            var mapped = _mapper.Map<Publisher>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }

        [HttpPut]
        [Route("updateGame_Publisher")]
        public async Task<IActionResult> UpdateGame_Publisher(Game_PublisherDTO dto)
        {
            var mapped = _mapper.Map<Game_Publisher>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }

        [HttpPut]
        [Route("updatePlatform")]
        public async Task<IActionResult> UpdatePlatform(PlatformDTO dto)
        {
            var mapped = _mapper.Map<Platform>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }

        [HttpPut]
        [Route("updateGame_Platform")]
        public async Task<IActionResult> UpdateGame_Platform(Game_PlatformDTO dto)
        {
            var mapped = _mapper.Map<Game_Platform>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }

        [HttpPut]
        [Route("updateRegion")]
        public async Task<IActionResult> UpdateRegion(RegionDTO dto)
        {
            var mapped = _mapper.Map<Region>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }

        [HttpPut]
        [Route("updateRegion_Sales")]
        public async Task<IActionResult> UpdateRegion_Sales(Region_SalesDTO dto)
        {
            var mapped = _mapper.Map<Region_Sales>(dto);

            if (mapped != null)
            {
                await _videoGamesService.UpdateAsync(mapped);
                return Ok("Updated");
            }
            else
                return NotFound("Not found");
        }
        #endregion
    }
}
