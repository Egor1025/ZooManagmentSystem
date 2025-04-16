using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Application;
using ZooManagmentSystem.Infrastructure;
namespace ZooManagmentSystem.Tests.ApplicationTests;

public class FeedingOrganizationServiceTests
{
    [Fact]
    public void FeedAnimal_AddsScheduleAndMarksCompleted()
    {
        var repo = new InMemoryFeedingScheduleRepository();
        var service = new FeedingOrganizationService(repo);
        var animal = new Animal("Zebra", "Marty", DateTime.Now, Gender.Male, "Grass");
        var feedingTime = DateTime.Now.AddHours(1);
        var evt = service.FeedAnimal(animal, feedingTime, "Grass");
        Assert.True(evt.FeedingSchedule.IsCompleted);
        Assert.Contains(evt.FeedingSchedule, repo.GetAll());
    }
}