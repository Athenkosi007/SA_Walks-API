
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA_Walks.API.Models.Domain;

namespace SA_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            //Hard code 
            /*var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Buffalo City Municipality",
                    Code = "BCM",
                    RegionImageUrl = "https://dearsouthafrica.co.za/buffalo-city/"

                },
               new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Nelson Mandela Bay",
                    Code = "NMB",
                    RegionImageUrl = ""

                }


            };

            return Ok(regions); */
        }
    }
}
