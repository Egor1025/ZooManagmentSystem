using Xunit;
using ZooManagmentSystem.Domain;
namespace ZooManagmentSystem.Tests.DomainTests;

public class FeedingScheduleTests
{
    [Fact]
    public void ChangeSchedule_UpdatesFeedingTimeAndFoodType()
    {
        var animal = new Animal("Giraffe", "Melman", DateTime.Now, Gender.Male, "Leaves");
        var schedule = new FeedingSchedule(animal, DateTime.Now, "Leaves");
        var newTime = DateTime.Now.AddHours(1);
        schedule.ChangeSchedule(newTime, "Fresh Leaves");
        Assert.Equal(newTime, schedule.FeedingTime);
        Assert.Equal("Fresh Leaves", schedule.FoodType);
    }
    [Fact]
    public void MarkAsCompleted_SetsIsCompletedAndReturnsEvent()
    {
        var animal = new Animal("Giraffe", "Melman", DateTime.Now, Gender.Male, "Leaves");
        var schedule = new FeedingSchedule(animal, DateTime.Now, "Leaves");
        var evt = schedule.MarkAsCompleted();
        Assert.True(schedule.IsCompleted);
        Assert.NotNull(evt);
    }
}