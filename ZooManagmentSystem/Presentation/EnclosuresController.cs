using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
namespace ZooManagmentSystem.Presentation;


[ApiController]
[Route("api/enclosures")]
public class EnclosuresController : ControllerBase
{
    private readonly IEnclosureRepository enclosureRepository;
    public EnclosuresController(IEnclosureRepository repo)
    {
        enclosureRepository = repo;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(enclosureRepository.GetAll());
    }
    [HttpPost]
    public IActionResult Add([FromBody] EnclosureDto dto)
    {
        var enclosure = new Enclosure(dto.Type, dto.Size, dto.MaxCapacity);
        enclosureRepository.Add(enclosure);
        return Ok(enclosure);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var enclosure = enclosureRepository.GetById(id);
        if(enclosure == null) return NotFound();
        enclosureRepository.Remove(enclosure);
        return Ok();
    }
}

public class EnclosureDto
{
    public string Type { get; set; }
    public double Size { get; set; }
    public int MaxCapacity { get; set; }
}