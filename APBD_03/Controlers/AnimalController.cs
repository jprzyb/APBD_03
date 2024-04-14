using APBD_03.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_03.Controlers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    /// <summary>
    /// Endpoints used to return list of animals.
    /// </summary>
    /// <returns>List of animals</returns>
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var students = _animalService.GetAnimals();
        return Ok(students);
    }
    
    
}