using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
namespace ZooManagmentSystem.Presentation;


[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository animalRepository;
    public AnimalsController(IAnimalRepository repo)
    {
        animalRepository = repo;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(animalRepository.GetAll());
    }
    [HttpPost]
    public IActionResult Add([FromBody] AnimalDto dto)
    {
        var animal = new Animal(dto.Species, dto.Name, dto.BirthDate, dto.Gender, dto.FavoriteFood);
        animalRepository.Add(animal);
        return Ok(animal);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var animal = animalRepository.GetById(id);
        if(animal == null) return NotFound();
        animalRepository.Remove(animal);
        return Ok();
    }
}

public class AnimalDto
{
    public string Species { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string FavoriteFood { get; set; }
}