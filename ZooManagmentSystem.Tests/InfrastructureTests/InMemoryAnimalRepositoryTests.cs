using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
namespace ZooManagmentSystem.Tests.InfrastructureTests;

public class InMemoryAnimalRepositoryTests
{
    [Fact]
    public void AddGetRemoveAnimal_WorksCorrectly()
    {
        var repo = new InMemoryAnimalRepository();
        var animal = new Animal("Bear", "Baloo", DateTime.Now, Gender.Male, "Honey");
        repo.Add(animal);
        Assert.NotNull(repo.GetById(animal.Id));
        Assert.Contains(animal, repo.GetAll());
        repo.Remove(animal);
        Assert.Null(repo.GetById(animal.Id));
    }
}