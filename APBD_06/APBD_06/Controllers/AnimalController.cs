using APBD_06.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_06.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _service;

    public AnimalController(IAnimalService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAnimals(string sortBy)
    {
        var animals = _service.GetAnimals(sortBy);
        return Ok(animals);
    }
}