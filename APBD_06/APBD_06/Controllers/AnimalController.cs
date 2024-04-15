using Microsoft.AspNetCore.Mvc;

namespace APBD_06.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents(string sortBy)
    {
        
        return Ok();
    }
}