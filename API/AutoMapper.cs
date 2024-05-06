using API.DTO_s;
using AutoMapper;
using Infrastructure.Entities;

namespace API
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
           CreateMap<Game,GameDTO>();
           CreateMap<Genre,GenreDTO>();
           CreateMap<Game_Publisher,Game_PublisherDTO>();
           CreateMap<Game_Platform,Game_PlatformDTO>();
           CreateMap<Platform,PlatformDTO>();
           CreateMap<Publisher, PublisherDTO>();
           CreateMap<Region, RegionDTO>();
           CreateMap<Region_Sales, Region_SalesDTO>();
        }
    }
}
