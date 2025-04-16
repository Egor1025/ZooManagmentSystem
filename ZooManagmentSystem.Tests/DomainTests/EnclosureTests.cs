using Xunit;
using ZooManagmentSystem.Domain;
namespace ZooManagmentSystem.Tests.DomainTests;

public class EnclosureTests
{
    [Fact]
    public void AddAnimal_AddsAnimalToEnclosure()
    {
        var enclosure = new Enclosure("Birds", 50, 1);
        var animal = new Animal("Parrot", "Polly", DateTime.Now, Gender.Female, "Seeds");
        enclosure.AddAnimal(animal);
        Assert.Contains(animal, enclosure.Animals);
    }
    [Fact]
    public void AddAnimal_WhenFull_ThrowsException()
    {
        var enclosure = new Enclosure("Birds", 50, 1);
        var animal1 = new Animal("Parrot", "Polly", DateTime.Now, Gender.Female, "Seeds");
        var animal2 = new Animal("Parrot", "Kitty", DateTime.Now, Gender.Male, "Seeds");
        enclosure.AddAnimal(animal1);
        Assert.Throws<Exception>(() => enclosure.AddAnimal(animal2));
    }
    [Fact]
    public void RemoveAnimal_RemovesAnimalFromEnclosure()
    {
        var enclosure = new Enclosure("Birds", 50, 2);
        var animal = new Animal("Parrot", "Polly", DateTime.Now, Gender.Female, "Seeds");
        enclosure.AddAnimal(animal);
        enclosure.RemoveAnimal(animal);
        Assert.DoesNotContain(animal, enclosure.Animals);
    }
}