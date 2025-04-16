using Xunit;
using ZooManagmentSystem.Domain;
namespace ZooManagmentSystem.Tests.DomainTests;

public class AnimalTests
{
    [Fact]
    public void TransferTo_ChangesEnclosureAndReturnsEvent()
    {
        var source = new Enclosure("Herbivores", 100, 2);
        var target = new Enclosure("Carnivores", 100, 2);
        var animal = new Animal("Lion", "Simba", new DateTime(2015, 1, 1), Gender.Male, "Meat");
        source.AddAnimal(animal);
        var evt = animal.TransferTo(target);
        Assert.DoesNotContain(animal, source.Animals);
        Assert.Contains(animal, target.Animals);
        Assert.Equal(target, animal.CurrentEnclosure);
        Assert.NotNull(evt);
    }
    [Fact]
    public void Heal_SetsHealthStatusToHealthy()
    {
        var animal = new Animal("Elephant", "Dumbo", new DateTime(2010, 5, 5), Gender.Female, "Vegetables");
        animal.Heal();
        Assert.Equal(HealthStatus.Healthy, animal.HealthStatus);
    }
}