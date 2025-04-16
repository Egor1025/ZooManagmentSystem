using Xunit;
using ZooManagmentSystem.Domain;
using ZooManagmentSystem.Infrastructure;
namespace ZooManagmentSystem.Tests.InfrastructureTests;

public class InMemoryFeedingScheduleRepositoryTests
{
    [Fact]
    public void AddGetRemoveFeedingSchedule_WorksCorrectly()
    {
        var repo = new InMemoryFeedingScheduleRepository();
        var animal = new Animal("Penguin", "Pingu", DateTime.Now, Gender.Male, "Fish");
        var schedule = new FeedingSchedule(animal, DateTime.Now, "Fish");
        repo.Add(schedule);
        Assert.NotNull(repo.GetById(schedule.Id));
        Assert.Contains(schedule, repo.GetAll());
        repo.Remove(schedule);
        Assert.Null(repo.GetById(schedule.Id));
    }
}