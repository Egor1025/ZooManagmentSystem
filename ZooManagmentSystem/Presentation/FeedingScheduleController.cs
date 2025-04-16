using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
namespace ZooManagmentSystem.Presentation;


[ApiController]
[Route("api/feedings")]
public class FeedingScheduleController : ControllerBase
{
    private readonly IFeedingScheduleRepository scheduleRepository;
    public FeedingScheduleController(IFeedingScheduleRepository repo)
    {
        scheduleRepository = repo;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(scheduleRepository.GetAll());
    }
    [HttpPost]
    public IActionResult Add([FromBody] FeedingScheduleDto dto)
    {
        var animal = new Animal(dto.AnimalSpecies, dto.AnimalName, dto.AnimalBirthDate, dto.AnimalGender, dto.AnimalFavoriteFood);
        var schedule = new FeedingSchedule(animal, dto.FeedingTime, dto.FoodType);
        scheduleRepository.Add(schedule);
        return Ok(schedule);
    }
}

public class FeedingScheduleDto
{
    public string AnimalSpecies { get; set; }
    public string AnimalName { get; set; }
    public DateTime AnimalBirthDate { get; set; }
    public Gender AnimalGender { get; set; }
    public string AnimalFavoriteFood { get; set; }
    public DateTime FeedingTime { get; set; }
    public string FoodType { get; set; }
}