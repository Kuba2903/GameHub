using API.Add_DTO_s;
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
           //CreateMap<Game_Publisher,Game_PublisherDTO>();
           CreateMap<Game_Platform,Game_PlatformDTO>();
           CreateMap<Platform,PlatformDTO>();
           CreateMap<Publisher, PublisherDTO>();
           CreateMap<Region, RegionDTO>();
           CreateMap<Region_Sales, Region_SalesDTO>();


           CreateMap<GameDTO, Game>();
           CreateMap<GenreDTO, Genre>();
           //CreateMap<Game_PublisherDTO, Game_Publisher>();
           CreateMap<Game_PlatformDTO, Game_Platform>();
           CreateMap<PlatformDTO, Platform>();
           CreateMap<PublisherDTO, Publisher>();
           CreateMap<RegionDTO, Region>();
           CreateMap<Region_SalesDTO, Region_Sales>();


           CreateMap<AddGameDTO, Game>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddGenreDTO, Genre>().ForMember(x => x.Id, opt => opt.Ignore());
           //CreateMap<AddGame_PublisherDTO, Game_Publisher>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddGame_PlatformDTO, Game_Platform>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddPlatformDTO, Platform>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddPublisherDTO, Publisher>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddRegionDTO, Region>().ForMember(x => x.Id, opt => opt.Ignore());
           CreateMap<AddRegion_SalesDTO, Region_Sales>();
        }
    }
}
