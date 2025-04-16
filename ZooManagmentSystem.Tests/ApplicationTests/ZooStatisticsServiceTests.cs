using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
using ZooManagmentSystem.Infrastructure;
namespace ZooManagmentSystem.Tests.ApplicationTests;

public class ZooStatisticsServiceTests
{
    [Fact]
    public void GetStatistics_ReturnsCorrectValues()
    {
        var animalRepo = new InMemoryAnimalRepository();
        var enclosureRepo = new InMemoryEnclosureRepository();
        var enclosure1 = new Enclosure("Herbivores", 100, 2);
        var enclosure2 = new Enclosure("Carnivores", 100, 2);
        enclosureRepo.Add(enclosure1);
        enclosureRepo.Add(enclosure2);
        var animal1 = new Animal("Elephant", "Dumbo", DateTime.Now, Gender.Male, "Grass");
        var animal2 = new Animal("Giraffe", "Melman", DateTime.Now, Gender.Female, "Leaves");
        animalRepo.Add(animal1);
        animalRepo.Add(animal2);
        enclosure1.AddAnimal(animal1);
        var service = new ZooStatisticsService(animalRepo, enclosureRepo);
        var stats = service.GetStatistics();
        Assert.Equal(2, stats.totalAnimals);
        Assert.Equal(1, stats.freeEnclosures);
    }
}