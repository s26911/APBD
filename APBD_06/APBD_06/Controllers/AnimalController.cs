using APBD_05.Models;
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
    public IActionResult GetAnimals([FromQuery] string orderBy)
    {
        var animals = _service.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimals([FromBody] Animal animal)
    {
        int rowsAffected = _service.AddAnimal(animal);
        return Created("Rows affected " + rowsAffected, rowsAffected);
    }
    [HttpPut]
    public IActionResult EditAnimal([FromBody] Animal animal)
    {
        _service.EditAnimal(animal);
        return NoContent();
    }
    [HttpDelete]
    public IActionResult DeleteAnimal(int id)
    {
        _service.DeleteAnimal(id);
        return NoContent();
    }
    
}