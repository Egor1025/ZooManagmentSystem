using Xunit;
using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
using ZooManagmentSystem.Presentation;
namespace ZooManagmentSystem.Tests.PresentationTests;

public class FeedingScheduleControllerTests
{
    [Fact]
    public void AddAndGetAll_WorksCorrectly()
    {
        var repo = new InMemoryFeedingScheduleRepository();
        var controller = new FeedingScheduleController(repo);
        var dto = new FeedingScheduleDto {
            AnimalSpecies = "Zebra",
            AnimalName = "Marty",
            AnimalBirthDate = DateTime.Now,
            AnimalGender = Gender.Male,
            AnimalFavoriteFood = "Grass",
            FeedingTime = DateTime.Now,
            FoodType = "Grass"
        };
        var addResult = controller.Add(dto) as OkObjectResult;
        Assert.NotNull(addResult);
        var allResult = controller.GetAll() as OkObjectResult;
        var schedules = allResult.Value as IEnumerable<FeedingSchedule>;
        Assert.Single(schedules);
    }
}