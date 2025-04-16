using Xunit;
using Microsoft.AspNetCore.Mvc;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
using ZooManagmentSystem.Presentation;
namespace ZooManagmentSystem.Tests.PresentationTests;

public class AnimalsControllerTests
{
    [Fact]
    public void AddAndGetAll_WorksCorrectly()
    {
        var repo = new InMemoryAnimalRepository();
        var controller = new AnimalsController(repo);
        var dto = new AnimalDto { Species = "Lion", Name = "Simba", BirthDate = DateTime.Now, Gender = Gender.Male, FavoriteFood = "Meat" };
        var addResult = controller.Add(dto) as OkObjectResult;
        Assert.NotNull(addResult);
        var allResult = controller.GetAll() as OkObjectResult;
        var animals = allResult.Value as IEnumerable<Animal>;
        Assert.Single(animals);
    }
    [Fact]
    public void Delete_WorksCorrectly()
    {
        var repo = new InMemoryAnimalRepository();
        var controller = new AnimalsController(repo);
        var animal = new Animal("Lion", "Simba", DateTime.Now, Gender.Male, "Meat");
        repo.Add(animal);
        var deleteResult = controller.Delete(animal.Id) as OkResult;
        Assert.NotNull(deleteResult);
        Assert.Empty(repo.GetAll());
    }
}