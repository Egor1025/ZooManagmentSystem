using Xunit;
using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
using ZooManagmentSystem.Presentation;
namespace ZooManagmentSystem.Tests.PresentationTests;

public class EnclosuresControllerTests
{
    [Fact]
    public void AddAndGetAll_WorksCorrectly()
    {
        var repo = new InMemoryEnclosureRepository();
        var controller = new EnclosuresController(repo);
        var dto = new EnclosureDto { Type = "Aquarium", Size = 200, MaxCapacity = 5 };
        var addResult = controller.Add(dto) as OkObjectResult;
        Assert.NotNull(addResult);
        var allResult = controller.GetAll() as OkObjectResult;
        var enclosures = allResult.Value as IEnumerable<Enclosure>;
        Assert.Single(enclosures);
    }
    [Fact]
    public void Delete_WorksCorrectly()
    {
        var repo = new InMemoryEnclosureRepository();
        var controller = new EnclosuresController(repo);
        var enclosure = new Enclosure("Aquarium", 200, 5);
        repo.Add(enclosure);
        var deleteResult = controller.Delete(enclosure.Id) as OkResult;
        Assert.NotNull(deleteResult);
        Assert.Empty(repo.GetAll());
    }
}