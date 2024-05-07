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


           CreateMap<GameDTO, Game>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<GenreDTO, Genre>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<Game_PublisherDTO, Game_Publisher>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<Game_PlatformDTO, Game_Platform>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<PlatformDTO, Platform>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<PublisherDTO, Publisher>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<RegionDTO, Region>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<Region_SalesDTO, Region_Sales>();
        }
    }
}
