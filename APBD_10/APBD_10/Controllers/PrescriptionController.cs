using APBD_10.RequestModels;
using APBD_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _service;
    public PrescriptionController(IPrescriptionService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddPrescription(PrescriptionRequest prescriptionRequest)
    {
        if (!_service.AddPrescription(prescriptionRequest))
        {
            return StatusCode(400);
        };
        return Ok();
    }
}