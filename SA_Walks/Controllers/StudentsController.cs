using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SA_Walks.API.Controllers
{

    //https: //localhost:portnumber/api/Students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentnames = new string[] { " John", "Jane", "Mark", "Emily", "David" };

            return Ok(studentnames);
        }
    }
}
