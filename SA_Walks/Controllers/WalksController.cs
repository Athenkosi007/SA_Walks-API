using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SA_Walks.API.Models.DTO;
using AutoMapper;
using SA_Walks.API.Models.Domain;
using SA_Walks.API.Repositories;

namespace SA_Walks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create walk
        // POST: api/walks

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           //Map DTO to Domain Model (using AutoMapper)
            var walkDomainModel = mapper.Map<SA_Walks.API.Models.Domain.Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain Model to DTO (using AutoMapper)
            var walkDto = mapper.Map<SA_Walks.API.Models.DTO.WalkDto>(walkDomainModel);
            //Return the DTO
            //return CreatedAtAction(nameof(Create), new { id = walkDto.Id }, walkDto);
            return Ok(walkDomainModel);

        }
        
          
        
    }
}
