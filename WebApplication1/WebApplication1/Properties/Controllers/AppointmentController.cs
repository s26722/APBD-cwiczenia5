using Microsoft.AspNetCore.Mvc;
using WebApplication1.Properties.Models;

namespace WebApplication1.Properties.Controllers;

[Route("api/appointment")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private static readonly List<Appointment> _appointments = new List<Appointment>
    {
        new Appointment { animalId = 1, appointmentDesc = "Pobranie krwi", appointmentTime = DateTime.Now, price = 70 }

    };
    

  

    
    [HttpGet("{animalId:int}")]
    public IActionResult GetAppointmentForAnimal(int animalId)
    {
        var appointment = _appointments.FirstOrDefault(ap => ap.animalId == animalId);
        if (appointment == null)
        {
            return NotFound("Nie zanleziono wizyty dla tego zwierzęcia");
        }
        return Ok(appointment);
    }

 
    [HttpPost]
    public IActionResult AddAppointment(Appointment appointment)
    {
       _appointments.Add(appointment);
       return StatusCode(StatusCodes.Status201Created);
    }

  
}