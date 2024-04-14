using Microsoft.AspNetCore.Mvc;
using WebApplication1.Properties.Models;

namespace WebApplication1.Properties.Controllers;
[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        
        new Animal { id = 1, name = "Luna", category = "pies", skinColor= "brązowo-czarna", wage = 20.5 },
        new Animal { id = 2, name= "Pestka", category = "kot", skinColor = "szaro-czarna", wage = 5.7},
      
    };



    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.id == id);
        if (animal == null)
        {
            return NotFound("Nie znaleziono zwierzęcia o id:" + id);
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id,Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(an => an.id == id);
        if (animalToEdit == null)
        {
            return NotFound("Nie znaleziono zwierzęcia o id:" + id);
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();


    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var animalToEdit= _animals.FirstOrDefault(an => an.id == id);
        if (animalToEdit == null)
        {
            return NoContent();
        }

        _animals.Remove(animalToEdit);
        return NoContent();
    }


    

}