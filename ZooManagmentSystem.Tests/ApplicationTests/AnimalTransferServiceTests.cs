using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
namespace ZooManagmentSystem.Tests.ApplicationTests;

public class AnimalTransferServiceTests
{
    [Fact]
    public void Transfer_ReturnsAnimalMovedEvent()
    {
        var source = new Enclosure("Herbivores", 100, 2);
        var target = new Enclosure("Carnivores", 100, 2);
        var animal = new Animal("Tiger", "Shera", DateTime.Now, Gender.Male, "Meat");
        source.AddAnimal(animal);
        var service = new AnimalTransferService();
        var evt = service.Transfer(animal, target);
        Assert.NotNull(evt);
        Assert.Equal(target, animal.CurrentEnclosure);
    }
}