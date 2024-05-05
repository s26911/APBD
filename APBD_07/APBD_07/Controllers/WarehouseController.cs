using APBD_07.Models;
using APBD_07.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07.Controllers;

[Route("api/warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _service;

    public WarehouseController(IWarehouseService service)
    {
        _service = service;
    }

    [HttpPut]
    public IActionResult Edit([FromBody] Warehouse warehouse)
    {
        _service.Edit(warehouse);
        return NoContent();
    }
}