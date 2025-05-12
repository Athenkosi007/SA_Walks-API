using AutoMapper;
using SA_Walks.API.Models.DTO;
using SA_Walks.API.Models.Domain;


namespace SA_Walks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<DomainModel, DtoModel>();
            CreateMap<SA_Walks.API.Models.Domain.Region, SA_Walks.API.Models.DTO.RegionDto>()
                .ReverseMap();

            CreateMap<AddRegionRequestDto, SA_Walks.API.Models.Domain.Region>()
                .ReverseMap();

            CreateMap<UpdateRegionRequestDto, SA_Walks.API.Models.Domain.Region>()
               .ReverseMap();
        }
    }
    

    
}
