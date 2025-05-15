using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SA_Walks.API.Models.DTO;
using AutoMapper;
using SA_Walks.API.Models.Domain;
using SA_Walks.API.Repositories;
using Microsoft.EntityFrameworkCore;
using SA_Walks.API.CustomActionFilters;

namespace SA_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
                      
                //DTO to Domain Model (using AutoMapper)
                var walkDomainModel = mapper.Map<SA_Walks.API.Models.Domain.Walk>(addWalkRequestDto);

                await walkRepository.CreateAsync(walkDomainModel);

                //Map Domain Model to DTO (using AutoMapper)
                
                return Ok(mapper.Map<SA_Walks.API.Models.DTO.WalkDto>(walkDomainModel));
                    

        }

        //GET: 
        //GET walk
        //GET: /api/walks

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var walksDomainModel = await walkRepository.GetAllAsync();

            //Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));


        }

        //GET BY ID
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //update walk 
        //update: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
           
            

                //Map Dto to Domain Model
                var walkDomainModel = mapper.Map<SA_Walks.API.Models.Domain.Walk>(updateWalkRequestDto);

                //walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                //Map Domain Model to DTO
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
           
        }
        //Delete walk
        //DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));

        }
    }
}
