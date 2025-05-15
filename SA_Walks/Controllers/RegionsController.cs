
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SA_Walks.API.CustomActionFilters;
using SA_Walks.API.Data;
using SA_Walks.API.Models.Domain;
using SA_Walks.API.Models.DTO;
using SA_Walks.API.Repositories;


namespace SA_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly SA_WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //CTOR - SHORCUT FOR CREATING A CONSTRUCTOR
        public RegionsController(SA_WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GetAll Regions
        //GET :https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            //Get data from database - domain model
            //var regionsDomain = await regionRepository.GetAllAsync();

            //Get data from database - domain model (via the repository interface)
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}

            //Map Domain Models to DTOs (using AutoMapper)
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            //Return Dtos
            return Ok(regionsDto);
        }

        // Get single region by Id
        //GET :https://localhost:portnumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            //Get Region Domain model from Database

            //var region = dbContext.Regions.Find(id);
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);
            
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Region DTO
            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            //Return Dto back to client
            //return Ok(regionDto);

            //Return Dto back to client (using AutoMapper)
            return Ok(mapper.Map<RegionDto>(regionDomain));
            

        }

        //POST To Create New Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionsRequestDto)
        {
                                    
                //Map DTO to Domain Model (using AutoMapper)
                var regionDomainModel = mapper.Map<Region>(addRegionsRequestDto);

                //Use Domain model to create region
                await dbContext.Regions.AddAsync(regionDomainModel);
                await dbContext.SaveChangesAsync();

                //Map Domain model back to DTO (using AutoMapper)
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);          
             
            
        }
        //Update Region
        //PUT https://localhost:portnumber/api/region/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
            
                //Map DTO to Domain Model (using AutoMapper)
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                //Check if region exists
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }


                //Convert Domain Model to DTO (using AutoMapper)
                return Ok(mapper.Map<RegionDto>(regionDomainModel));
            
           
        }


        //Delet region
        //DELETE: https://localhost:portnumber/api/region/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete region
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            //Map DTO to Domain Model
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);

        }

    }
}
