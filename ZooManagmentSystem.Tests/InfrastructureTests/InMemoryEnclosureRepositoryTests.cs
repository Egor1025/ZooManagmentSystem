using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
namespace ZooManagmentSystem.Tests.InfrastructureTests;

public class InMemoryEnclosureRepositoryTests
{
    [Fact]
    public void AddGetRemoveEnclosure_WorksCorrectly()
    {
        var repo = new InMemoryEnclosureRepository();
        var enclosure = new Enclosure("Aquarium", 200, 5);
        repo.Add(enclosure);
        Assert.NotNull(repo.GetById(enclosure.Id));
        Assert.Contains(enclosure, repo.GetAll());
        repo.Remove(enclosure);
        Assert.Null(repo.GetById(enclosure.Id));
    }
}