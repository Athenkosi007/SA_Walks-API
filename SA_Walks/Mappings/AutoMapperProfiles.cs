using AutoMapper;
using SA_Walks.API.Models.DTO;
using SA_Walks.API.Models.Domain;
using SA_Walks.API.Data;


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

            CreateMap<AddWalkRequestDto, SA_Walks.API.Models.Domain.Walk>()
               .ReverseMap();

            CreateMap<SA_Walks.API.Models.Domain.Walk, SA_Walks.API.Models.DTO.WalkDto>()
                .ReverseMap();

            CreateMap<SA_Walks.API.Models.Domain.Difficulty, SA_Walks.API.Models.DTO.DifficultyDto>()
                .ReverseMap();

            CreateMap<SA_Walks.API.Models.DTO.UpdateWalkRequestDto, SA_Walks.API.Models.Domain.Walk >()
                    .ReverseMap();
        }
    }
    

    
}
